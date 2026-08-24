using System.Collections.Generic;
using BattleEngine.Work.Event.ComponentEvent;
using BattleEngine.Work.Step.CompStep;
using BattleEngine.Work.Step.Target;
using NUnit.Framework;

namespace BattleEngine.Work.Step.Resolver
{
    public class RemoveCompStepResolver : IStepResolver<RemoveCompStep>
    {
        public List<IExecutable> Resolve(RemoveCompStep step, BattleState state)
        {
            Assert.IsInstanceOf<IdTarget>(step.Target);
            var events = new List<IExecutable>();
            
            var target = state.GetUnit(((IdTarget)step.Target).Id);
            if  (target == null) return events;
            
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