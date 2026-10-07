namespace BattleEngine.Work
{
    public abstract record WorkItem()
    {
        public int Priority { get; init; } = 0;
    }
}