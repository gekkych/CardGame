using System.Collections.Generic;
using System.Linq;
using BattleEngine.Command;
using BattleEngine.Command.Resolver;
using BattleEngine.Id.RuntimeId;
using BattleEngine.Reaction;
using BattleEngine.Reaction.UnitReaction;
using BattleEngine.Work;
using BattleEngine.Work.Event;
using BattleEngine.Work.Event.Applier;
using BattleEngine.Work.Step;
using BattleEngine.Work.Step.Interfaces;
using BattleEngine.Work.Step.Target;

namespace BattleEngine
{
    public class BattleEngine
    {
        private readonly WorkScheduler _work = new();

        private readonly List<BaseEvent> _history = new();
        private readonly List<BaseEvent> _buff = new();
        private readonly List<BaseReaction> _reactions = new();
        private readonly Dictionary<int, UnitId> _lastTargets = new();

        private BattleState _state;
        //#TODO make later IReadOnlyBattleState
        public BattleState State => _state;

        public BattleEngine(int start, int width, int height)
        {
            _state = new BattleState(start, width, height);
        }

        public BattleEngine(BattleState initialState)
        {
            _state = initialState;
        }

        public void TestInit(BattleState initialState)
        {
            _state = initialState;

            _reactions.Add(new DeathR());
            _reactions.Add(new ThornR());
            _reactions.Add(new HealerUnitR());
            _reactions.Add(new VampirismR());

            _reactions.Sort((x, y) => x.Priority.CompareTo(y.Priority));
        }

        public List<BaseEvent> Turn(CommandContext ctx)
        {
            foreach (var react in _reactions)
            {
                react.NewTurn();
            }

            Execute(CommandDispatch.Resolve(_state, ctx));

            _history.AddRange(_buff);
            _buff.Clear();
            _lastTargets.Clear();

            return EndBattle();
        }

        public List<BaseEvent> EndBattle()
        {
            var result = _history.ToList();
            _history.Clear();

            return result;
        }

        private void Execute(IEnumerable<BaseStep> rootSteps)
        {
            _work.Push(new EventWork(new EndTurnEvent(_state.Turn + 1), 0, 0));

            _work.PushRange(rootSteps.Select(step =>
                    (WorkItem)new StepWork(step, 0){Priority = step.Priority}));

            while (_work.TryPop(out var work))
            {
                switch (work)
                {
                    case StepWork step:
                        ProcessStep(step.Step, step.Depth);
                        break;

                    case EventWork evt: 
                        ProcessEvent(evt.Event, evt.Depth, evt.NextReact, evt.Applied);
                        break;
                }
            }
        }

        private void ProcessStep(BaseStep step, int depth)
        {
            if (depth == 0)
            {
                foreach (var react in _reactions)
                {
                    react.NewRootStep();
                }
            }

            var currPriority = step.Priority;

            List<IExecutable> executables = new();
            _lastTargets.TryGetValue(depth, out var last);

            executables.AddRange(
                TargetResolver.Resolve(
                    step,
                    _state,
                    last?.Raw ?? UnitId.Placeholder.Raw));

            if (executables.Count == 0)
            {
                if (step is IStepWithTarget swt)
                {
                    if (((IdTarget)swt.GetTarget()).Id.To<UnitId>(out var id))
                    {
                        _lastTargets[depth - 1] = id;
                    }
                }

                executables.AddRange(StepDispatch.Resolve(step, _state));
            }

            _work.PushRange(
                executables.Select<IExecutable, WorkItem>(executable =>
                    executable switch
                    {
                        BaseEvent evt =>
                            new EventWork(evt, depth + 1, 0)
                            {
                                Applied = false,
                                Priority = currPriority
                            },

                        BaseStep childStep =>
                            new StepWork(childStep, depth + 1)
                            {
                                Priority = childStep.Priority
                            },

                        _ => throw new System.InvalidOperationException(
                            $"Unsupported executable: {executable.GetType()}")
                    }));
        }

        private void ProcessEvent(BaseEvent e, int depth, int nextReaction, bool applied)
        {
            if (!applied)
            {
                EventApplier.Apply(e, _state);
                _buff.Add(e);
                _work.Push(new EventWork(e, depth, 0) {Applied = true, Priority = 0});
                return;
            }

            if (nextReaction >= _reactions.Count)
                return;

            var reaction = _reactions[nextReaction];
            var steps = reaction.React(e, _state).ToList();
            
            // Reaction on event always has prior zero
            // Result of reaction can be manage locally, so it may have nonzero prior
            _work.Push(new EventWork(e, depth, nextReaction + 1){Applied = true, Priority = 0});
            _work.PushRange(steps.Select(step => (WorkItem)new StepWork(step,depth + 1){Priority = step.Priority}));
        }
    }
}