using System.Collections.Generic;
using BattleEngine.Work.Event.ComponentEvent;
using BattleEngine.Work.Step.CompStep;
using BattleEngine.Work.Step.Target;
using NUnit.Framework;

namespace BattleEngine.Work.Step.Resolver
{
    public class AddCompStepResolver : IStepResolver<AddCompStep>
    {
        public List<IExecutable> Resolve(AddCompStep step, BattleState state)
        {
            Assert.IsInstanceOf<IdTarget>(step.Target);
            var events = new List<IExecutable>();
            
            var target = state.GetUnit(((IdTarget)step.Target).Id);
            if  (target == null) return events;
            
            if (target.HasComp(step.Component.Name)) return events;
            
            events.Add(new AddCompEvent(
                target.UnitId,
                target.Stats.Type.ToString(),
                step.Component.Name,
                step.Component
            ));
            
            return events;
        }
    }
}