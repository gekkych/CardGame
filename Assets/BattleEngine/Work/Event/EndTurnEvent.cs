namespace BattleEngine.Work.Event
{
    public record EndTurnEvent(
        int NewTurnNumber
        ) : BaseEvent;
}