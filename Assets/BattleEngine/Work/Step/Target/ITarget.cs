using System.Collections.Generic;

namespace BattleEngine.Work.Step.Target
{
    public interface ITarget
    {
        public List<int?> ResolveTarget(BattleState state, int lastId);
    }
}