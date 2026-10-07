using System.Linq;
using BattleEngine.Cards;
using BattleEngine.Id;
using BattleEngine.Work.Step.Interfaces;

namespace BattleEngine.Work.Step.Target
{
    public class PatternTarget : ITarget,  ITargetPosOffset
    {
        private readonly Position _center;
        private readonly Pattern _pattern;

        public PatternTarget(Position center, Pattern pattern)
        {
            _center = center;
            _pattern = pattern;
        }
        
        public TargetResult ResolveTarget(BattleState state, IdUnion lastId)
        {
            return new TargetResult(state.Board.GetUnitsInPattern(_center, _pattern)
                .Select(u => u.UnitId.Raw)
                .ToList(), true);
        }

        public ITarget Offset(Position offset)
        {
            return new PatternTarget(_center+offset, _pattern);
        }
    }
}