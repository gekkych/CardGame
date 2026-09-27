using BattleEngine.Id;

namespace BattleEngine.Work.Event
{
    public record HealEvent(
        IdUnion Healer,
        string HealerName,
        IdUnion Target,
        string ToName,
        int Amount,
        int OldValue,
        int NewValue
        ) : BaseEvent;
}