using BattleEngine.Enums;

namespace BattleEngine.Unit.Component
{
    public record BurnComp(
        int Damage, 
        int RemainingTurn
        ) : BaseComponent(ComponentName.Burn);
}