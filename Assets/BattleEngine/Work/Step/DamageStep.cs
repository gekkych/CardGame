using BattleEngine.Enums;

namespace BattleEngine.Work.Step
{
    public record DamageStep(
        int Amount,
        int To,
        int From,
        DamageSource Source
        ) : BaseStep;
}