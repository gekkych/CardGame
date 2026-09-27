using System.Collections.Generic;
using System.Linq;
using BattleEngine.Battler;
using BattleEngine.Cards;
using BattleEngine.Enums;
using BattleEngine.Id;
using BattleEngine.Id.RuntimeId;
using BattleEngine.Unit;
using JetBrains.Annotations;

namespace BattleEngine
{
    public class BattleState
    {
        public IdProvider IdProvider { get; }
        public BaseBattler Player { get; set; }
        public BaseBattler Opponent { get; set; }
        public Board Board { get; set; }
        
        public int Turn { get; set; }

        public BattleState(int start, int width, int height)
        {
            IdProvider = new IdProvider(start);
            Player = null;
            Opponent = null;
            Board = new Board(width, height);
            Turn = 1;
        }

        [CanBeNull]
        public BaseUnit GetUnit(UnitId id)
        {
            return Board.GetUnit(id);
        }

        public BaseBattler GetBattler(BattlerId id)
        {
            if (Player.BattlerData.BattlerId.Equals(id)) return Player;
            if (Opponent.BattlerData.BattlerId.Equals(id)) return Opponent;
            return null;
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

        [CanBeNull]
        public List<BaseUnit> GetUnitsInPattern(Position center, Pattern pattern)
        {
            return Board.GetUnitsInPattern(center, pattern);
        }

        public void BattlerDied(BattlerId id)
        {
            throw new System.NotImplementedException();
        }

        public bool Exists(IdUnion id)
        {
            if (id.To<UnitId>(out var unitId)) return Board.GetUnit(unitId) != null;
            if (id.To<BattlerId>(out var battlerId)) return GetBattler(battlerId) != null;
            throw new System.NotImplementedException();
        }
    }
}