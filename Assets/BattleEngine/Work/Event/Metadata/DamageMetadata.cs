namespace BattleEngine.Work.Event.Metadata
{
    public record DamageMetadata(
        EntityMetadata Attacker,
        EntityMetadata Target,
        int OldValue,
        int NewValue);
}