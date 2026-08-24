using System.Collections.Generic;
using BattleEngine.Calculation;
using BattleEngine.Work.Event;
using BattleEngine.Work.Step.Target;
using BattleEngine.Work.Step.UnitStateStep;
using NUnit.Framework;

namespace BattleEngine.Work.Step.Resolver
{
    public class HealStepResolver : IStepResolver<HealStep>
    {
        public List<IExecutable> Resolve(HealStep step, BattleState state)
        {
            Assert.IsInstanceOf<IdTarget>(step.Target);
            var events = new List<IExecutable>();

            var healer = state.GetUnit(step.Healer);
            var target = state.GetUnit(((IdTarget)step.Target).Id);
            if (healer == null) return events;
            if (target == null) return events;

            var actual = HealCalculator.Calc(step, state);
            
            events.Add(new HealEvent(
                step.Healer, 
                healer.Stats.Type.ToString(),
                target.UnitId, 
                target.Stats.Type.ToString(),
                actual, 
                target.State.CurrHp,
                target.State.CurrHp + actual));
            
            return events;
        }
    }
}