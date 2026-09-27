using BattleEngine.Enums;
using BattleEngine.Id.RuntimeId;

namespace BattleEngine.Work.Event
{
    public record BonusChangeEvent(
        UnitId Id,
        string Name,
        StatsBonuses Bonus,
        int Delta
        ) : BaseEvent;
}