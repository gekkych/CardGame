using BattleEngine.Enums;

namespace BattleEngine.Work.Step
{
    public record BonusChangeStep(
        int Id,
        StatsBonuses Bonus,
        int Delta
        ) : BaseStep;
}