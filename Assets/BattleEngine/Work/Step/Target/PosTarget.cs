using System.Collections.Generic;
using BattleEngine.Cards;
using BattleEngine.Id;
using BattleEngine.Work.Step.Interfaces;

namespace BattleEngine.Work.Step.Target
{
    public class PosTarget : ITarget, ITargetPosOffset
    {
        private Position _pos;
        public Position Pos  => _pos;
        
        public PosTarget(Position pos) => _pos = pos;


        public TargetResult ResolveTarget(BattleState state, IdUnion lastId)
        {
            List<IdUnion> ids = new();
            ids.Add(state.GetUnitAt(_pos)?.UnitId.Raw);
            return new TargetResult(ids);
        }
        public override string ToString() => _pos.ToString();
        
        public ITarget Offset(Position offset)
        {
            return new PosTarget(_pos + offset);
        }
    }
}