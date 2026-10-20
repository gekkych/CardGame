using System.Collections.Generic;
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
            var target = new List<IdUnion>();
            if (_dir.Equals(Position.Zero)) return new TargetResult(target);
            
            
            var maybepos = state.Board.GetPosition(_attacker);
            if (maybepos is not {} pos) return new TargetResult(target);
            var curr = pos + _dir;
            while (state.Board.InBounds(curr))
            {
                var unit = state.Board.GetUnitAt(curr);
                if (unit != null) 
                {
                    target.Add(unit.UnitId.Raw);
                    return new TargetResult(target);
                }
                curr += _dir;
            }

            var battler = state.BattlersStateManager.GetBattlerAtExit(curr);
            if (battler != null) target.Add(battler.BattlerData.BattlerId.Raw);

            return new TargetResult(target);
        }
    }
}