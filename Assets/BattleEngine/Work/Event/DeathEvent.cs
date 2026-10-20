using BattleEngine.Id;
using BattleEngine.Work.Event.Metadata;

namespace BattleEngine.Work.Event
{
    public record DeathEvent(
        IdUnion Target,
        DeathMetadata Metadata
    ) : BaseEvent;
}