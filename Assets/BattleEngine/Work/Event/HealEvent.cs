namespace BattleEngine.Work.Event
{
    public record HealEvent(
        int Amount,
        int To,
        string ToName,
        int OldValue,
        int NewValue
        ) : BaseEvent;
}