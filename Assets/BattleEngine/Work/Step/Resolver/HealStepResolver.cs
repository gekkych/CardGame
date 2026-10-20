using System.Collections.Generic;
using BattleEngine.Calculation;
using BattleEngine.State;
using BattleEngine.Work.Event;
using BattleEngine.Work.Event.Metadata;
using BattleEngine.Work.Step.Target;
using BattleEngine.Work.Step.UnitStateStep;

namespace BattleEngine.Work.Step.Resolver
{
    public class HealStepResolver : IStepResolver<HealStep>
    {
        public List<IExecutable> Resolve(HealStep step, BattleState state)
        {
            var events = new List<IExecutable>();

            var targetId = ((IdTarget)step.Target).Id;
            var healer = EntityMetadata.FromState(step.Healer, state);
            var target = EntityMetadata.FromState(targetId, state);
            if (healer == null) return events;
            if (target == null) return events;

            var actual = HealCalculator.Calc(step, state);
            if (actual <= 0) return events;
            
            events.Add(new HealEvent(
                step.Healer,
                targetId,
                actual,
                new HealMetadata(healer, target, target.Health, target.Health + actual)));
            
            return events;

        }
    }
}