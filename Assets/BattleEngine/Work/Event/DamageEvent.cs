using BattleEngine.Enums;
using BattleEngine.Id;
using BattleEngine.Id.RuntimeId;

namespace BattleEngine.Work.Event
{
    public record DamageEvent(
        IdUnion Attacker,
        string AttackerName,
        IdUnion Target,
        string TargetName,
        int Amount,
        DamageSource Source,
        int OldValue,
        int NewValue)
        : BaseEvent;
}