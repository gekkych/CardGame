using System.Collections.Generic;
using BattleEngine.Id.RuntimeId;
using BattleEngine.Work.Event.ComponentEvent;
using BattleEngine.Work.Step.CompStep;
using BattleEngine.Work.Step.Target;

namespace BattleEngine.Work.Step.Resolver
{
    public class AddCompStepResolver : IStepResolver<AddCompStep>
    {
        public List<IExecutable> Resolve(AddCompStep step, BattleState state)
        {
            var events = new List<IExecutable>();
            var ltarget = (IdTarget)step.Target;

            if (!ltarget.Id.To<UnitId>(out var target)) return events;
            var targetUnit = state.GetUnit(target);
            
            if  (targetUnit == null) return events;
            if (targetUnit.HasComp(step.Component.Name)) return events;
            
            events.Add(new AddCompEvent(
                targetUnit.UnitId,
                targetUnit.Stats.Type.ToString(),
                step.Component.Name,
                step.Component
            ));
            
            return events;
        }
    }
}