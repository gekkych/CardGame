using BattleEngine.Enums;

namespace BattleEngine.Unit.Component.UnitAbilityCompTags
{
    public record HealerUnitComp(int Amount) : BaseComponent(ComponentName.HealerUnit);
}