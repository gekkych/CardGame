using System.Collections.Generic;
using System.Linq;
using BattleEngine.Cards;
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
        
        public List<int?> ResolveTarget(BattleState state, int lastId)
        {
            return new List<int?>
                (state.Board.GetUnitsInPattern(_center, _pattern)
                    .Select((u) => u?.UnitId));
        }
    }
}