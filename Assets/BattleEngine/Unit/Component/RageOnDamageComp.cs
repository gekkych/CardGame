using BattleEngine.Enums;

namespace BattleEngine.Unit.Component
{
    public record RageOnDamageComp(
        int StrengthAmount,
        int RemainingTurns
        ) : BaseComponent(ComponentName.RageOnDamage);
}