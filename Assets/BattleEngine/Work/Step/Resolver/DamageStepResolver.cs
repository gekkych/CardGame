using System.Collections.Generic;
using BattleEngine.Calculation;
using BattleEngine.State;
using BattleEngine.Work.Event;
using BattleEngine.Work.Event.Metadata;
using BattleEngine.Work.Step.Target;
using BattleEngine.Work.Step.UnitStateStep;

namespace BattleEngine.Work.Step.Resolver
{
    public class DamageStepResolver : IStepResolver<DamageStep>
    {
        public List<IExecutable> Resolve(DamageStep step, BattleState state)
        {
            var events = new List<IExecutable>();

            var targetId = ((IdTarget)step.Target).Id;
            var attacker = EntityMetadata.FromState(step.Attacker, state);
            var target = EntityMetadata.FromState(targetId, state);
            if (attacker == null) return events;
            if (target == null) return events;

            var actual = DamageCalculator.Calc(step, state);
            if (actual <= 0) return events;
            
            events.Add(new DamageEvent(
                step.Attacker,
                targetId,
                actual,
                step.Source,
                new DamageMetadata(attacker, target, target.Health, target.Health - actual)));
            
            return events;

        }
    }
}