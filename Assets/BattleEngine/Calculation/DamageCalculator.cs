using BattleEngine.Work.Step;

//test calc
namespace BattleEngine.Calculation
{
    public class DamageCalculator
    {
        public int Calc(DamageStep step, BattleState state)
        {
            int targetHp = state.GetUnit(step.To).State.CurrHp;
            return step.Amount > targetHp ? targetHp : step.Amount;
        }
    }
}