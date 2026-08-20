using System.Collections.Generic;
using BattleEngine.Calculation;
using BattleEngine.Unit;
using BattleEngine.Work.Event;
using BattleEngine.Work.Step.Target;
using BattleEngine.Work.Step.UnitStateStep;
using NUnit.Framework;

namespace BattleEngine.Work.Step.Resolver
{
    public static class DamageStepResolver
    {
        public static List<IExecutable> Resolve(DamageStep step, BattleState state)
        {
            Assert.IsInstanceOf<IdTarget>(step.Target);
            var events = new List<IExecutable>();

            var attacker = state.GetUnit(step.Attacker);
            var target = state.GetUnit(((IdTarget)step.Target).Id);
            if (attacker == null) return events;
            if (target == null) return events;

            var actual = DamageCalculator.Calc(step, state);
            
            events.Add(new DamageEvent(
                step.Attacker, 
                attacker.Stats.Type.ToString(),
                target.UnitId, 
                target.Stats.Type.ToString(),
                actual, 
                step.Source,
                target.State.CurrHp,
                target.State.CurrHp - actual));
            
            return events;

        }
    }
}