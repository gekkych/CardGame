using System;

namespace BattleEngine.Cards
{
    public struct Position : IEquatable<Position>
    {
        public int X;
        public int Y;
        
        public static Position? Error                => null;
        public static Position Zero                  => new(0, 0);
        public static Position Up                    => new(0, 1);
        public static Position Down                  => new(0, -1);
        public static Position Left                  => new(-1, 0);
        public static Position Right                 => new(1, 0);
        public static Position Pos(int x, int y)     => new(x, y);

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static Position operator +(Position a, Position b)
        {
            return new Position(a.X + b.X, a.Y + b.Y);
        }

        public override bool Equals(object obj)
        {
            if (obj is Position other)
            {
                return (X == other.X && Y == other.Y);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }
        
        public override string ToString() => $"({X}, {Y})";

        public bool Equals(Position other)
        {
            return X == other.X && Y == other.Y;
        }
    }
}