using System.Collections.Generic;
using BattleEngine.Id;
using BattleEngine.State;

namespace BattleEngine.Work.Step.Target
{
    public class IdGroupTarget : ITarget
    {
        private readonly List<IdUnion> _ids = new();
        
        public void Append(IdUnion id) => _ids.Add(id);
        
        public TargetResult ResolveTarget(BattleState state, IdUnion lastId)
        {
            return TargetResult.Group(_ids);
        }
    }
}