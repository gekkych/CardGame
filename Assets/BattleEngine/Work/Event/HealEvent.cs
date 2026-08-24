namespace BattleEngine.Work.Event
{
    public record HealEvent(
        int Healer,
        string HealerName,
        int To,
        string ToName,
        int Amount,
        int OldValue,
        int NewValue
        ) : BaseEvent;
}