using System.Collections.Generic;

namespace BattleEngine.Work.Step.Target
{
    public class SameAsLast : ITarget
    {
        public List<int?> ResolveTarget(BattleState state, int lastId)
        {
            List<int?> ids = new();
            ids.Add(lastId);
            return ids;
        }
        
        public override string ToString() => "SameAsLast";
    }
}