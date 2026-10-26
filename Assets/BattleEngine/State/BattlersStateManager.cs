using System;
using System.Collections.Generic;
using System.Linq;
using BattleEngine.Battler;
using BattleEngine.Cards;
using BattleEngine.Enums;
using BattleEngine.Id.RuntimeId;

namespace BattleEngine.State
{
    //mutates State
    //mutation only via EventApplier 
    public class BattlersStateManager
    {
        private readonly BattleState _lookUpState;
        private readonly HashSet<BattlerId> _deadBattlers = new();
        private readonly BattlersLayout _layout;
        
        public BattlersStateManager(BattleState lookUpState)
        {
            _lookUpState = lookUpState;
            _layout = new BattlersLayout(_lookUpState);
        }

        public BaseBattler GetBattler(BattlerId battlerId)
        {
            if (battlerId == null || _deadBattlers.Contains(battlerId)) return null;

            return _lookUpState.Players.Concat(_lookUpState.Opponents)
                .FirstOrDefault(b => b?.BattlerData.BattlerId.Equals(battlerId) ?? false);
        }
        
        public BoardSide? GetSide(BattlerId battlerId)
        {
            if (_lookUpState.Players.Any(b => b?.BattlerData.BattlerId.Equals(battlerId) ?? false))
                return BoardSide.Player;
            if (_lookUpState.Opponents.Any(b => b?.BattlerData.BattlerId.Equals(battlerId) ?? false))
                return BoardSide.Opponent;
            return null;
        }
        
        public BaseBattler GetBattlerOnLine(BoardSide side, int line)
        {
            if (!_layout.TryGetBattlerId(side, line, out var battlerId)) return null;

            var battler = GetBattler(battlerId);

            return battler != null && !battler.IsDead() ? battler : null;
        }

        public BaseBattler GetBattlerAtExit(Position exit)
        {
            if (exit.X < 0 || exit.X >= _lookUpState.Board.Width) return null;
            if (exit.Y < 0) return GetBattlerOnLine(BoardSide.Player, exit.X);
            if (exit.Y >= _lookUpState.Board.Height)
                return GetBattlerOnLine(BoardSide.Opponent, exit.X);
            return null;
        }

        public int Damage(BattlerId battlerId, int amount)
        {
            var battler = GetBattler(battlerId);
            if (battler == null || battler.IsDead()) return 0;

            int actual = Math.Clamp(amount, 0, battler.BattlerData.Shield);
            battler.BattlerData.Shield -= actual;
            return actual;
        }

        public int Heal(BattlerId battlerId, int amount)
        {
            var battler = GetBattler(battlerId);
            if (battler == null || battler.IsDead()) return 0;

            int missing = Math.Max(0, battler.BattlerData.MaxShield - battler.BattlerData.Shield);
            int actual = Math.Clamp(amount, 0, missing);
            battler.BattlerData.Shield += actual;
            return actual;
        }

        public void BattlerDied(BattlerId battlerId)
        {
            var battler = GetBattler(battlerId);
            if (battler == null) return;

            battler.BattlerData.Shield = 0;
            _deadBattlers.Add(battlerId);
        }

        private List<BaseBattler> GetBattlers(BoardSide side)
        {
            return side switch
            {
                BoardSide.Player => _lookUpState.Players,
                BoardSide.Opponent => _lookUpState.Opponents,
                _ => throw new ArgumentOutOfRangeException(nameof(side), side, null)
            };
        }
    }
}