using BattleEngine.Id;

namespace BattleEngine.Work.Event
{
    public record DeathEvent(
        IdUnion Target,
        string ToName
        ) : BaseEvent;
}