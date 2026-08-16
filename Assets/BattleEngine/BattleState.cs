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

        public BattleState(int width, int height)
        {
            Player = null;
            Opponent = null;
            Board = new Board(width, height);
            Turn = 1;
        }

        public BaseUnit GetUnit(int unitId)
        {
            return Board.GetUnit(unitId);
        }

        public BaseUnit GetUnitAt(Position pos)
        {
            return Board.GetUnitAt(pos);
        }

        public List<BaseUnit> GetAllUnits()
        {
            return Board.GetAllUnits();
        }
    }
}