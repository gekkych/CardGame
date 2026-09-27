using BattleEngine.Enums;
using BattleEngine.Id.DefId;

namespace BattleEngine.Unit
{
    public record UnitStats(
        UnitDef Type,
        int MaxHealth,
        int BaseStrength
        );
}