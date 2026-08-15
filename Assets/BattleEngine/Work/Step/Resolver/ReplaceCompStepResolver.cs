using System.Collections.Generic;
using BattleEngine.Unit.Component;
using BattleEngine.Work.Event;
using BattleEngine.Work.Event.ComponentEvent;
using BattleEngine.Work.Step.ComponentStep;

namespace BattleEngine.Work.Step.Resolver
{
    public class ReplaceCompStepResolver : IStepResolver<ReplaceCompStep>
    {
        public List<IExecutable> Resolve(ReplaceCompStep step, BattleState state)
        {
            var events = new List<IExecutable>();
            
            var target = state.GetUnit(step.Target);
            if  (target == null) return events;
            
            if (!target.HasComp(step.ToReplace)) return events;

            var old = target.GetComp(step.ToReplace);
            
            events.Add(new ReplaceCompEvent(
                step.Target,
                target.Stats.Type.ToString(),
                step.ToReplace,
                old,
                step.Relacement
                ));
            
            return events;
        }
    }
}