using BattleEngine.Enums;

namespace BattleEngine.Unit.Component
{
    public record VampirismComp(int BaseHeal) : BaseComponent(ComponentName.Vampirism);
}