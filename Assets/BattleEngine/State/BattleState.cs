using System.Collections.Generic;
using BattleEngine.Battler;
using BattleEngine.Cards;
using BattleEngine.Id;
using BattleEngine.Id.RuntimeId;
using BattleEngine.Unit;
using JetBrains.Annotations;

namespace BattleEngine.State
{
    public class BattleState
    {
        public IdProvider IdProvider { get; }
        public BattlersStateManager BattlersStateManager { get; }
        public List<BaseBattler> Players { get; set; }
        public List<BaseBattler> Opponents { get; set; }
        public Board Board { get; set; }
        
        public int Turn { get; set; }

        public BattleState(int start, int width, int height)
        {
            IdProvider = new IdProvider(start);
            BattlersStateManager = new BattlersStateManager(this);
            Players = new List<BaseBattler>();
            Opponents = new List<BaseBattler>();
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
            return BattlersStateManager.GetBattler(id);
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

        public bool Exists(IdUnion id)
        {
            if (id.To<UnitId>(out var unitId)) return Board.GetUnit(unitId) != null;
            if (id.To<BattlerId>(out var battlerId)) return GetBattler(battlerId) != null;
            throw new System.NotImplementedException();
        }
    }
}