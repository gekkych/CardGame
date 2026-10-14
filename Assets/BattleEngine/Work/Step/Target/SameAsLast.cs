using System.Collections.Generic;
using BattleEngine.Id;
using BattleEngine.State;

namespace BattleEngine.Work.Step.Target
{
    public class SameAsLast : ITarget
    {
        public TargetResult ResolveTarget(BattleState state, IdUnion lastId)
        {
            List<IdUnion> ids = new();
            ids.Add(lastId);
            return new TargetResult(ids);
        }
        
        public override string ToString() => "SameAsLast";
    }
}