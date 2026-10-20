namespace BattleEngine.Work.Event.Metadata
{
    public record DeathMetadata(
        EntityMetadata Target,
        int OldValue,
        int NewValue);
}