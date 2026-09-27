using System.Collections.Generic;
using BattleEngine.Cards;
using BattleEngine.Unit;

namespace BattleEngine.Work.Step.Target
{
    public class FirstOnLineTarget : ITarget
    {
        private readonly BaseUnit _attacker;
        
        public FirstOnLineTarget(BaseUnit attacker) => _attacker = attacker;
        
        public List<int?> ResolveTarget(BattleState state, int lastId)
        {
            var target = new List<int?>();

            var maybepos = state.Board.GetPosition(_attacker);
            if (maybepos is not {} pos) return target;
            var curr = pos + Position.Up;
            while (state.Board.InBounds(curr))
            {
                if (state.Board.GetUnitAt(curr) != null) 
                {
                    target.Add(state.Board.GetUnitAt(curr).UnitId);
                    return target;
                }
                curr += Position.Up;
            }
            
            target.Add(-69); //#TODO make battler id acceptable in unit targting
            
            return  target;
        }
    }
}