using System.Collections.Generic;
using BattleEngine.Cards;
using NUnit.Framework;

namespace BattleEngine.Work.Step.Target
{
    public class PosTarget : ITarget
    {
        private Position _pos;
        public Position Pos  => _pos;
        
        public PosTarget(Position pos) { 
            _pos = pos;
            
        }

        public List<int?> ResolveTarget(BattleState state, int lastId)
        {
            Assert.IsNotNull(_pos);
            List<int?> ids = new();
            ids.Add(state.GetUnitAt(_pos)?.UnitId);
            return ids;
        }
    }
}