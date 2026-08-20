using System.Collections.Generic;
using System.Linq;
using BattleEngine.Battler;
using BattleEngine.Cards;
using BattleEngine.Unit;
using JetBrains.Annotations;

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

        [CanBeNull]
        public BaseUnit GetUnit(int unitId)
        {
            return Board.GetUnit(unitId);
        }

        [CanBeNull]
        public BaseUnit GetUnitAt(Position pos)
        {
            return Board.GetUnitAt(pos);
        }

        [CanBeNull]
        public List<BaseUnit> GetAllUnits()
        {
            return Board.GetAllUnits();
        }
    }
}