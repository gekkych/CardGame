using System;
using System.Collections.Generic;
using System.Linq;
using BattleEngine.Unit;

namespace BattleEngine.Cards
{
    public class Board
    {
        private Dictionary<Position, BaseUnit> _positions = new();
        public int Width { get; set; }
        public int Height { get; set; }
        private Position MaxPosition => new Position(Width - 1, Height - 1);

        public Board(int w, int h)
        {
            Width = w;
            Height = h;
            
            for (int i = 0; i < w; i++)
            {
                for (int j = 0; j < h; j++)
                {
                    _positions.Add(new Position(i, j), null);
                }
            }
        }

        public bool InBounds(Position pos)
        {
            return pos.x >= 0 &&
                   pos.x < Width &&
                   pos.y >= 0 &&
                   pos.y < Height;
        }
        
        public BaseUnit GetUnit(int id)
        {
            return _positions.Values.FirstOrDefault(u => u?.UnitId == id);
        }

        public Position? GetPosition(BaseUnit unit)
        {
            foreach (var p in _positions.Keys.ToList())
            {
                if (unit.UnitId == _positions[p].UnitId) return p;
            }

            return Position.Error;
        }

        public BaseUnit GetUnitAt(Position pos)
        {
            if (!InBounds(pos)) return null;
            return _positions.GetValueOrDefault(pos);
        }

        public List<BaseUnit> GetAllUnits()
        {
            return _positions.Values.Where(u => u != null).ToList();
        }

        public List<BaseUnit> GetUnitsInPattern(Position center, Pattern pattern)
        {
            return pattern.GetAbsolutePositions(center)
                .Where(InBounds)
                .Select(GetUnitAt)
                .Where(u => u != null)
                .ToList();
        }

        public void Add(Position pos, BaseUnit unit)
        {
            if (!_positions.ContainsKey(pos)) throw new ArgumentException("no pos");
            if (!InBounds(pos)) return;
            if (_positions[pos] != null) return;
            _positions[pos] = unit;
        }
        
        public void RemoveAt(Position pos)
        {
            if (!_positions.ContainsKey(pos))
                throw new ArgumentException("no pos");

            if (!InBounds(pos))
                return;

            _positions[pos] = null;
        }

        public void Remove(int id)
        {
            foreach (var pos in _positions.Keys
                         .Where(pos => _positions[pos]?.UnitId == id)
                         .ToList())
            {
                _positions.Remove(pos);
            }
        }
    }
}