namespace BattleEngine.Work.Step.Interfaces
{
    public abstract record BaseStep : IExecutable
    {
        public int Priority { get; init; } = 0;
    }
}