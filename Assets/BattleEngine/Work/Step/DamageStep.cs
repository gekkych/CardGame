using BattleEngine.Cards;
using BattleEngine.Enums;

namespace BattleEngine.Work.Step
{
    public record DamageStep(
        int Amount,
        Position Pos,
        int From,
        DamageSource Source
        ) : BaseStep;
}