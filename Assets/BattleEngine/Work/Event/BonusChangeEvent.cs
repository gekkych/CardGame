using BattleEngine.Enums;

namespace BattleEngine.Work.Event
{
    public record BonusChangeEvent(
        int Id,
        string Name,
        StatsBonuses Bonus,
        int Delta
        ) : BaseEvent;
}