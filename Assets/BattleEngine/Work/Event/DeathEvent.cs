namespace BattleEngine.Work.Event
{
    public record DeathEvent(
        int To,
        string ToName
        ) : BaseEvent;
}