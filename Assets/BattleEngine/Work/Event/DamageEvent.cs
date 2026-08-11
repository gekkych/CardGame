using BattleEngine.Enums;

namespace BattleEngine.Work.Event
{
    public record DamageEvent(
        int Attacker,
        string AttackerName,
        int Target,
        string TargetName,
        int Amount,
        DamageSource Source,
        int OldValue,
        int NewValue)
        : BaseEvent;
}