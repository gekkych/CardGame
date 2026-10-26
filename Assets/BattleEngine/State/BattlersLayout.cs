using System.Collections.Generic;
using BattleEngine.Battler;
using BattleEngine.Enums;
using BattleEngine.Id.RuntimeId;

namespace BattleEngine.State
{
    public class BattlersLayout
    {
        private readonly Dictionary<int, BattlerId> _enemy1 = new();
        private readonly Dictionary<BattlerId, List<int>> _enemy2 = new();

        private readonly Dictionary<int, BattlerId> _player1 = new();
        private readonly Dictionary<BattlerId, List<int>> _player2 = new();

        public BattlersLayout(BattleState battleState)
        {
            FromBattlers(battleState.Players, battleState.Board, BoardSide.Player);
            FromBattlers(battleState.Opponents, battleState.Board, BoardSide.Opponent);
        }

        private void FromBattlers(List<BaseBattler> battlers, Board board, BoardSide side)
        {
            var lineToBattler = side == BoardSide.Player ? _player1 : _enemy1;
            var battlerToLines = side == BoardSide.Player ? _player2 : _enemy2;

            int width = board.Width;
            int count = battlers.Count;

            if (count == 0 || width <= 0) return;

            int baseLines = width / count;
            int remainder = width % count;
            
            var linesPerBattler = new int[count];

            for (int i = 0; i < count; i++)
                linesPerBattler[i] = baseLines;
            
            int left = (count - 1) / 2;
            int right = count / 2;

            while (remainder > 0)
            {
                if (left == right)
                {
                    linesPerBattler[left]++;
                    remainder--;
                    left--;
                    right++;
                }
                else
                {
                    if (remainder >= 2)
                    {
                        linesPerBattler[left]++;
                        linesPerBattler[right]++;
                        remainder -= 2;
                    }
                    else
                    {
                        if (count % 2 == 1)
                        {
                            linesPerBattler[count / 2]++;
                        }
                        else
                        {
                            linesPerBattler[left]++;
                        }

                        remainder--;
                    }
                    left--;
                    right++;
                }

                if (left < 0 || right >= count)
                {
                    left = 0;
                    right = count - 1;

                    while (remainder > 0 && left <= right)
                    {
                        if (left == right)
                        {
                            linesPerBattler[left]++;
                            remainder--;
                        }
                        else if (remainder >= 2)
                        {
                            linesPerBattler[left]++;
                            linesPerBattler[right]++;
                            remainder -= 2;
                        }
                        else
                        {
                            linesPerBattler[left]++;
                            remainder--;
                        }

                        left++;
                        right--;
                    }

                    break;
                }
            }

            int start = 0;

            for (int i = 0; i < count; i++)
            {
                int linesCount = linesPerBattler[i];
                var battler = battlers[i];

                if (battler != null)
                {
                    BattlerId id = battler.BattlerData.BattlerId;
                    var lines = new List<int>(linesCount);

                    for (int j = 0; j < linesCount; j++)
                    {
                        int line = start + j;

                        lineToBattler[line] = id;
                        lines.Add(line);
                    }

                    battlerToLines[id] = lines;
                }

                start += linesCount;
            }
        }

        public bool TryGetBattlerId(BoardSide side, int line, out BattlerId battlerId)
        {
            var lookup = side == BoardSide.Player ? _player1 : _enemy1;

            return lookup.TryGetValue(line, out battlerId);
        }

        public bool TryGetLines(BoardSide side, BattlerId battlerId, out List<int> lines)
        {
            var lookup = side == BoardSide.Player ? _player2 : _enemy2;

            return lookup.TryGetValue(battlerId, out lines);
        }
    }
}