using BattleEngine.Work.Event;

namespace BattleEngine.Work
{
    public record EventWork(BaseEvent Event, int Depth, int NextReact) : WorkItem
    {
        public bool Applied{ get; init; } = false;

        public override string ToString()
        {
            return $"EventWork(" +
                   $"Event={Event}, " +
                   $"Depth={Depth}, " +
                   $"NextReact={NextReact}, " +
                   $"Applied={Applied}," +
                   $"Priority={Priority})";
        }
    }
}