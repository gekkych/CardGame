using System.Collections.Generic;
using BattleEngine.Id.RuntimeId;
using BattleEngine.Work.Event.ComponentEvent;
using BattleEngine.Work.Step.CompStep;
using BattleEngine.Work.Step.Target;
using NUnit.Framework;

namespace BattleEngine.Work.Step.Resolver
{
    public class ReplaceCompStepResolver : IStepResolver<ReplaceCompStep>
    {
        public List<IExecutable> Resolve(ReplaceCompStep step, BattleState state)
        {
            Assert.IsInstanceOf<IdTarget>(step.Target);
            var events = new List<IExecutable>();
            
            if (!((IdTarget)step.Target).Id.To<UnitId>(out var targetId)) return events;
            var target = state.GetUnit(targetId);
            
            if  (target == null) return events;
            
            if (!target.HasComp(step.ToReplace)) return events;

            var old = target.GetComp(step.ToReplace);
            
            events.Add(new ReplaceCompEvent(
                target.UnitId,
                target.Stats.Type.ToString(),
                step.ToReplace,
                old,
                step.Relacement
            ));
            
            return events;
        }
    }
}