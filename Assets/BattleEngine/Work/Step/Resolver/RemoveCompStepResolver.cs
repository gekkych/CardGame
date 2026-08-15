using System.Collections.Generic;
using BattleEngine.Work.Event;
using BattleEngine.Work.Event.ComponentEvent;
using BattleEngine.Work.Step.ComponentStep;

namespace BattleEngine.Work.Step.Resolver
{
    public class RemoveCompStepResolver : IStepResolver<RemoveCompStep>
    {
        public List<IExecutable> Resolve(RemoveCompStep step, BattleState state)
        {
            var events = new List<IExecutable>();
            
            var target = state.GetUnit(step.Target);
            if  (target == null) return events;
            
            if (!target.HasComp(step.ComponentName)) return events;

            var removed = target.GetComp(step.ComponentName);
            
            events.Add(new RemoveCompEvent(
                step.Target,
                target.Stats.Type.ToString(),
                step.ComponentName,
                removed
                ));
            
            return events;
        }
    }
}