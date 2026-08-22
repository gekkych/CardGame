using BattleEngine.Enums;

namespace BattleEngine.Unit.Component.UnitAbilityCompTags
{
    public record HealerComp(int Amount) : BaseComponent(ComponentName.Healer);
}