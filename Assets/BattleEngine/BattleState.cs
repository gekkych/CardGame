using System.Collections.Generic;
using System.Linq;
using BattleEngine.Battler;
using BattleEngine.Cards;
using BattleEngine.Unit;

namespace BattleEngine
{
    public class BattleState
    {
        public BattlerData Player { get; set; }
        public BattlerData Opponent { get; set; }
        public Board Board { get; set; }
        
        public int Turn { get; set; }

        public BattleState()
        {
            Player = null;
            Opponent = null;
            Board = new Board();
            Turn = 1;
        }

        public BaseUnit GetUnit(int unitId)
        {
            if (unitId == -1) return null;
            
            if (Board.Good != null && Board.Good.UnitId == unitId) return Board.Good;
            if (Board.Bad != null && Board.Bad.UnitId == unitId) return Board.Bad;
            return null;
        }

        public List<BaseUnit> GetAllUnits()
        {
            var units = new List<BaseUnit>
            {
                Board.Good,
                Board.Bad
            };
            return units.Where(u => u != null).ToList();
        }
    }
}