using System;

namespace BattleEngine.Cards
{
    public struct Position
    {
        public int x;
        public int y;

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
    }
}