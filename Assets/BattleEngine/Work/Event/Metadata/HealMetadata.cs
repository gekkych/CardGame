namespace BattleEngine.Work.Event.Metadata
{
    public record HealMetadata(
        EntityMetadata Healer,
        EntityMetadata Target,
        int OldValue,
        int NewValue);
}