using System.Collections.Generic;
using BattleEngine.Cards;
using BattleEngine.Id;

namespace BattleEngine.Work.Step.Target
{
    public class PosTarget : ITarget
    {
        private Position _pos;
        public Position Pos  => _pos;
        
        public PosTarget(Position pos) => _pos = pos;


        public List<IdUnion> ResolveTarget(BattleState state, IdUnion lastId)
        {
            List<IdUnion> ids = new();
            ids.Add(state.GetUnitAt(_pos)?.UnitId.Raw);
            return ids;
        }
        public override string ToString() => _pos.ToString();
    }
}