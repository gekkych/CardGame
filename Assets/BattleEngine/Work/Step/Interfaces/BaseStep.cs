using BattleEngine.Id.RuntimeId;

namespace BattleEngine.Work.Step.Interfaces
{
    public abstract record BaseStep : IExecutable
    {
        public int Priority { get; init; } = 0;
        public GroupId GroupId { get; init; } = GroupId.Placeholder;
    }
}