using System.Collections.Generic;

namespace BattleEngine.Cards
{
    public class Pattern
    {
        public List<Position> Offsets { get; set; }
        
        public IEnumerable<Position> GetAbsolutePositions(Position center)
        {
            foreach (var offset in Offsets)
                yield return center + offset;
        }

        public static class Patterns
        {
            // Все клетки в квадрате radius x radius вокруг центра (0,0),
            // без центра
            public static Pattern Radius(int radius)
            {
                var offsets = new List<Position>();

                for (int dx = -radius; dx <= radius; dx++)
                {
                    for (int dy = -radius; dy <= radius; dy++)
                    {
                        if (dx == 0 && dy == 0)
                            continue; 

                        offsets.Add(new Position(dx, dy));
                    }
                }

                return new Pattern { Offsets = offsets };
            }

            // 8 соседних клеток вокруг центра (аналог Radius(1))
            public static Pattern Neighbors()
            {
                return Radius(1);
            }

            // "Крест": клетки по вертикали и горизонтали от центра
            // на расстояние до length, без диагоналей и без центра
            public static Pattern Cross(int length)
            {
                var offsets = new List<Position>();

                for (int i = 1; i <= length; i++)
                {
                    offsets.Add(new Position(i, 0));
                    offsets.Add(new Position(-i, 0));
                    offsets.Add(new Position(0, i));
                    offsets.Add(new Position(0, -i));
                }

                return new Pattern { Offsets = offsets };
            }
        }
    }
}