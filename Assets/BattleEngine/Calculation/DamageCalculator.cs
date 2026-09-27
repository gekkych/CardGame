using System;
using BattleEngine.Id.RuntimeId;
using BattleEngine.Unit;
using BattleEngine.Work.Step.Target;
using BattleEngine.Work.Step.UnitStateStep;

namespace BattleEngine.Calculation
{
    public static class DamageCalculator
    {
        //Ensure Target is IdTarget
        public static int Calc(DamageStep step, BattleState state)
        {
            var targetId = ((IdTarget) step.Target).Id;
            
            if (targetId.To<UnitId>(out var unitId)) return CalcUnit(step, state, unitId);
            if (targetId.To<BattlerId>(out var battlerId)) return CalcBattler(step, state);
            throw new Exception($"Unknown target id: {targetId}");
        }

        private static int CalcUnit(DamageStep step, BattleState state, UnitId unitId)
        {
            int damage = step.Amount;
            var targetUnit = state.GetUnit(unitId);
            
            //#TODO other types
            if (step.Attacker.To<UnitId>(out var attackerUnitId)) 
                damage += UnitAttackerBonus(state.GetUnit(attackerUnitId));
            
            int targetHp = targetUnit.State.CurrHp;
            return Math.Min(damage, targetHp);
        }

        private static int UnitAttackerBonus(BaseUnit attacker)
        {
            int damage = 0;
            damage += attacker.State.StrengthBonus;
            return damage;
        }

        //#TODO after battler
        private static int CalcBattler(DamageStep step, BattleState state)
        {
            return 0;
        }
    }
}