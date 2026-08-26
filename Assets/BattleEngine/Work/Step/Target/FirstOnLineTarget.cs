using System.Collections.Generic;
using BattleEngine.Cards;

namespace BattleEngine.Work.Step.Target
{
    public class FirstOnLineTarget : ITarget
    {
        private readonly Position _attackerPosition;
        
        public FirstOnLineTarget(Position attackerPosition) => _attackerPosition = attackerPosition;
        
        public List<int?> ResolveTarget(BattleState state, int lastId)
        {
            var target = new List<int?>();

            var curr = _attackerPosition + Position.Up;
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