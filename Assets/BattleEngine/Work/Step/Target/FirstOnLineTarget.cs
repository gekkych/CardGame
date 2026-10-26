using BattleEngine.Cards;
using BattleEngine.Id;
using BattleEngine.State;
using BattleEngine.Unit;

namespace BattleEngine.Work.Step.Target
{
    public class FirstOnLineTarget : ITarget
    {
        private readonly BaseUnit _attacker;
        private readonly Position _dir;

        public FirstOnLineTarget(BaseUnit attacker, Position dir)
        {
            _attacker = attacker;
            _dir = dir;
        }
        
        public TargetResult ResolveTarget(BattleState state, IdUnion lastId)
        {
            if (_dir.Equals(Position.Zero)) return TargetResult.None;
            
            
            var maybepos = state.Board.GetPosition(_attacker);
            if (maybepos is not {} pos) return TargetResult.None;
            var curr = pos + _dir;
            while (state.Board.InBounds(curr))
            {
                var unit = state.Board.GetUnitAt(curr);
                if (unit != null)
                {
                    return TargetResult.One(unit.UnitId);
                }
                curr += _dir;
            }

            var battler = state.BattlersStateManager.GetBattlerAtExit(curr);
            if (battler != null)
            {
                return TargetResult.One(battler.BattlerData.BattlerId);
            }

            return TargetResult.None;
        }
    }
}