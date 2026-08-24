using System;
using BattleEngine.Unit;
using BattleEngine.Work.Step.Target;
using BattleEngine.Work.Step.UnitStateStep;
using NUnit.Framework;

namespace BattleEngine.Calculation
{
    public static class HealCalculator
    {
        public static int Calc(HealStep step, BattleState state)
        {
            Assert.IsInstanceOf<IdTarget>(step.Target);
            int heal = step.Amount;
            var target = state.GetUnit(((IdTarget)step.Target).Id);
            var healer = state.GetUnit(step.Healer);
            heal += healer.State.StrengthBonus;
            int maximumToHeal = target.Stats.MaxHealth - target.State.CurrHp;
            
            return Math.Min(heal, maximumToHeal);
        }
    }
}