namespace BattleEngine.Work.Event
{
    public abstract record BaseEvent : IExecutable
    {
        public int Priority { get; init; } = 0;
    }
}