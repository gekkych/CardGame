using System;

namespace BattleEngine.Cards
{
    public struct Position
    {
        public int x;
        public int y;
        
        public static Position? Error => null;
        public static Position Zero => new Position(0, 0);
        public static Position Up => new Position(0, 1);
        public static Position Down => new Position(0, -1);
        public static Position Left => new Position(-1, 0);
        public static Position Right => new Position(1, 0);

        public Position(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public static Position operator +(Position a, Position b)
        {
            return new Position(a.x + b.x, a.y + b.y);
        }

        public override bool Equals(object obj)
        {
            if (obj is Position other)
            {
                return (x == other.x && y == other.y);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(x, y);
        }
        
        public override string ToString() => $"({x}, {y})";
    }
}