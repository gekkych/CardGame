using System;
using BattleEngine.Work.Step;
using BattleEngine.Work.Step.Target;
using BattleEngine.Work.Step.UnitStateStep;
using NUnit.Framework;

namespace BattleEngine.Calculation
{
    public static class DamageCalculator
    {
        //Ensure Target is IdTarget
        public static int Calc(DamageStep step, BattleState state)
        {
            Assert.IsInstanceOf<IdTarget>(step.Target);
            int damage = step.Amount;
            var target = state.GetUnit(((IdTarget)step.Target).Id);
            var attacker = state.GetUnit(step.Attacker);
            damage += attacker.State.StrengthBonus;
            int targetHp = target.State.CurrHp;
            return Math.Min(damage, targetHp);
        }
    }
}