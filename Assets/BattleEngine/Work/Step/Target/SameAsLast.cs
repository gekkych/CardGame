using System.Collections.Generic;
using BattleEngine.Id;

namespace BattleEngine.Work.Step.Target
{
    public class SameAsLast : ITarget
    {
        public List<IdUnion> ResolveTarget(BattleState state, IdUnion lastId)
        {
            List<IdUnion> ids = new();
            ids.Add(lastId);
            return ids;
        }
        
        public override string ToString() => "SameAsLast";
    }
}