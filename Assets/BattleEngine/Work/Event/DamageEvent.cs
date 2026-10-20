using BattleEngine.Enums;
using BattleEngine.Id;
using BattleEngine.Work.Event.Metadata;

namespace BattleEngine.Work.Event
{
    public record DamageEvent(
        IdUnion Attacker,
        IdUnion Target,
        int Amount,
        DamageSource Source,
        DamageMetadata Metadata)
        : BaseEvent;
}