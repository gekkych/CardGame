using System.Collections.Generic;
using System.Linq;
using BattleEngine.Cards;
using BattleEngine.Id;

namespace BattleEngine.Work.Step.Target
{
    public class PatternTarget : ITarget
    {
        private readonly Position _center;
        private readonly Pattern _pattern;

        public PatternTarget(Position center, Pattern pattern)
        {
            _center = center;
            _pattern = pattern;
        }
        
        public List<IdUnion> ResolveTarget(BattleState state, IdUnion lastId)
        {
            return state.Board.GetUnitsInPattern(_center, _pattern)
                .Select(u => u.UnitId.Raw)
                .ToList();
        }
    }
}