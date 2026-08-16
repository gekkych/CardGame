using BattleEngine.Enums;

namespace BattleEngine.Unit.Component
{
    public record ThornComp(
        int RemainingTurns
        ) :  BaseComponent(ComponentName.Thorn);
}