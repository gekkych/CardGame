using System.Collections.Generic;
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
            
            var target = state.GetUnit(((IdTarget)step.Target).Id);
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