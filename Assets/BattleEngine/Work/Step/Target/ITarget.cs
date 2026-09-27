using System.Collections.Generic;
using BattleEngine.Id;

namespace BattleEngine.Work.Step.Target
{
    public interface ITarget
    {
        public List<IdUnion> ResolveTarget(BattleState state, IdUnion lastId);
    }
}