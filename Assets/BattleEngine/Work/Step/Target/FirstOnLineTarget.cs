using System.Collections.Generic;
using BattleEngine.Cards;
using BattleEngine.Id;
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
        
        public List<IdUnion> ResolveTarget(BattleState state, IdUnion lastId)
        {
            var target = new List<IdUnion>();

            var maybepos = state.Board.GetPosition(_attacker);
            if (maybepos is not {} pos) return target;
            var curr = pos + _dir;
            while (state.Board.InBounds(curr))
            {
                if (state.Board.GetUnitAt(curr) != null) 
                {
                    target.Add(state.Board.GetUnitAt(curr).UnitId.Raw);
                    return target;
                }
                curr += _dir;
            }

            target.Add(_dir.y >= 0 ?
                state.Player.BattlerData.BattlerId.Raw
                : 
                state.Opponent.BattlerData.BattlerId.Raw);

            return  target;
        }
    }
}