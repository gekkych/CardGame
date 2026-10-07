using System.Collections.Generic;
using BattleEngine.Id;
using BattleEngine.Id.RuntimeId;

namespace BattleEngine.Work.Step.Target
{
    //end point target
    public class IdTarget : ITarget
    {
        private IdUnion _id;
        public IdUnion Id => _id;

        public IdTarget(IdUnion id) => _id = id;

        
        public TargetResult ResolveTarget(BattleState state, IdUnion lastId)
        {
            List<IdUnion> ids = new();
            if (_id.To<UnitId>(out var unitID)) ids.Add(unitID.Raw);
            if (_id.To<BattlerId>(out var battlerID)) ids.Add(battlerID.Raw);
            return new TargetResult(ids);
        }

        public override string ToString() => _id.ToString();
    }
}