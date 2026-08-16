using BattleEngine.Cards;
using BattleEngine.Enums;

namespace BattleEngine.Work.Step
{
    public record BonusChangeStep(
        Position Pos,
        StatsBonuses Bonus,
        int Delta
        ) : BaseStep;
}