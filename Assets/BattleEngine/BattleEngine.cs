using System.Collections.Generic;
using System.Linq;
using BattleEngine.Command;
using BattleEngine.Command.Resolver;
using BattleEngine.Reaction;
using BattleEngine.Unit;
using BattleEngine.Work;
using BattleEngine.Work.Event;
using BattleEngine.Work.Event.Applier;
using BattleEngine.Work.Step;
using BattleEngine.Work.Step.Resolver;

namespace BattleEngine
{
    public class BattleEngine
    {
        private LinkedList<WorkItem> _work = new();
        private List<BaseEvent> _history = new();
        private List<BaseEvent> _buff = new();
        private BattleState _state;
        private List<BaseReaction> _reactions = new();

        public BattleEngine(int width, int height)
        {
            UnitIdGenerator.Reset();
            _state = new BattleState(width, height);
        }
        
        public void TestInit(BattleState initialState)
        {
            _state = initialState;
            
            _reactions = new();
           var rs1 = new DeathR();
           _reactions.Add(rs1);
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
            return EndBattle();
        }

        public List<BaseEvent> EndBattle()
        {
            var r = _history.ToList();
            _history.Clear();
            return r;
        }
        
        private void Execute(IEnumerable<BaseStep> rootSteps)
        {
            _work.AddFirst(new EventWork(new EndTurnEvent(_state.Turn + 1), 0, 0));
            foreach (var step in rootSteps.Reverse())
                _work.AddFirst(new StepWork(step, 0));

            while (_work.Count > 0)
            {
                var work = _work.First!.Value;
                _work.RemoveFirst();

                switch (work)
                {
                    case StepWork step:
                        ProcessStep(step.Step,step.Depth);
                        break;

                    case EventWork evt:
                        ProcessEvent(evt.Event, evt.Depth, evt.NextReact);
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
            var events = StepDispatch.Resolve(step, _state).ToList();

            events.Reverse();
            foreach (var e in events)
            {
                switch (e)
                {
                    case BaseEvent be:
                        _work.AddFirst(new EventWork(be, depth + 1, 0));
                        break;
                    case BaseStep bs:
                        _work.AddFirst(new StepWork(bs, depth + 1));
                        break;
                }
            }
        }
        private void ProcessEvent(BaseEvent e, int depth, int nextReaction)
        {
            if (nextReaction == 0)
            {
                EventApplier.Apply(e, _state);
                _buff.Add(e);
            }

            if (nextReaction >= _reactions.Count)
                return;

            var reaction = _reactions[nextReaction];

            var steps = reaction
                .React(e, _state)
                .ToList();
            
            _work.AddFirst(
                new EventWork(e, depth + 1,nextReaction + 1));
            steps.Reverse();
            foreach (BaseStep step in steps)
                _work.AddFirst(
                    new StepWork(step, depth + 1));
        }
    }
}