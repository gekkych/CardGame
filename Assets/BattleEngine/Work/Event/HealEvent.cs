using BattleEngine.Id;
using BattleEngine.Work.Event.Metadata;

namespace BattleEngine.Work.Event
{
    public record HealEvent(
        IdUnion Healer,
        IdUnion Target,
        int Amount,
        HealMetadata Metadata
    ) : BaseEvent;
}