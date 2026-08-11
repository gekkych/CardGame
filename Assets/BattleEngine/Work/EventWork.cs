using BattleEngine.Work.Event;

namespace BattleEngine.Work
{
    public record EventWork(BaseEvent Event, int Depth, int NextReact) : WorkItem();
}