using System.Collections.Generic;
using BattleEngine.Id.RuntimeId;
using BattleEngine.Work.Event.ComponentEvent;
using BattleEngine.Work.Step.CompStep;
using BattleEngine.Work.Step.Target;

namespace BattleEngine.Work.Step.Resolver
{
    public class RemoveCompStepResolver : IStepResolver<RemoveCompStep>
    {
        public List<IExecutable> Resolve(RemoveCompStep step, BattleState state)
        {
            var events = new List<IExecutable>();
            
            if (!((IdTarget)step.Target).Id.To<UnitId>(out var targetId)) return events;
            var target = state.GetUnit(targetId);
            if (target == null) return events;
            
            if (!target.HasComp(step.ComponentName)) return events;

            var removed = target.GetComp(step.ComponentName);
            
            events.Add(new RemoveCompEvent(
                target.UnitId,
                target.Stats.Type.ToString(),
                step.ComponentName,
                removed
            ));
            
            return events;
        }
    }
}