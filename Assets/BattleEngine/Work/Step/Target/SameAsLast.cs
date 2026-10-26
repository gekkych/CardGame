using System.Collections.Generic;
using BattleEngine.Id;
using BattleEngine.State;

namespace BattleEngine.Work.Step.Target
{
    public class SameAsLast : ITarget
    {
        public TargetResult ResolveTarget(BattleState state, IdUnion lastId)
        {
            return TargetResult.One(lastId);
        }
        
        public override string ToString() => "SameAsLast";
    }
}