using BattleEngine.Id;
using BattleEngine.State;

namespace BattleEngine.Work.Step.Target
{
    public interface ITarget
    {
        public TargetResult ResolveTarget(BattleState state, IdUnion lastId);
    }
}