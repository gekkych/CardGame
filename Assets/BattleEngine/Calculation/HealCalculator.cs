using System;
using BattleEngine.Id.RuntimeId;
using BattleEngine.State;
using BattleEngine.Unit;
using BattleEngine.Work.Step.Target;
using BattleEngine.Work.Step.UnitStateStep;

namespace BattleEngine.Calculation
{
    public static class HealCalculator
    {
        //Ensure Target is IdTarget
        public static int Calc(HealStep step, BattleState state)
        {
            var targetId = ((IdTarget) step.Target).Id;
            
            if (targetId.To<UnitId>(out var unitId)) return CalcUnit(step, state, unitId);
            if (targetId.To<BattlerId>(out var battlerId)) return CalcBattler(step, state, battlerId);
            throw new Exception($"Unknown target id: {targetId}");
        }

        private static int CalcUnit(HealStep step, BattleState state, UnitId unitId)
        {
            int heal = step.Amount;
            var targetUnit = state.GetUnit(unitId);

            return Math.Clamp(heal, 0, targetUnit.Stats.MaxHealth - targetUnit.State.CurrHp);
        }

        private static int UnitHealerBonus(BaseUnit attacker)
        {
            return 0;
        }
        
        private static int CalcBattler(HealStep step, BattleState state, BattlerId battlerId)
        {
            var battler = state.GetBattler(battlerId);
            if (battler == null || battler.IsDead()) return 0;
            int missing = Math.Max(0, battler.BattlerData.MaxShield - battler.BattlerData.Shield);
            return Math.Clamp(step.Amount, 0, missing);
        }
    }
}