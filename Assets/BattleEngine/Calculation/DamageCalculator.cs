using BattleEngine.Work.Step;

//test calc
namespace BattleEngine.Calculation
{
    public class DamageCalculator
    {
        public int Calc(DamageStep step, BattleState state)
        {
            int damage = step.Amount;
            var target = state.GetUnit(step.To);
            var attacker = state.GetUnit(step.From);
            damage += attacker.State.StrengthBonus;
            int targetHp = target.State.CurrHp;
            return damage > targetHp ? targetHp : damage;
        }
    }
}