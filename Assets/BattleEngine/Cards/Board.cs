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
        }

        public BaseUnit GetUnit(int id)
        {
            return _positions.Values.FirstOrDefault(u => u?.UnitId == id);
        }

        public BaseUnit GetUnitAt(Position pos)
        {
            if (MaxPosition.x < pos.x || MaxPosition.y < pos.y) return null;
            return _positions.GetValueOrDefault(pos);
        }

        public List<BaseUnit> GetAllUnits()
        {
            return _positions.Values.Where(u => u != null).ToList();
        }

        public void Add(Position pos, BaseUnit unit)
        {
            if (MaxPosition.x < pos.x || MaxPosition.y < pos.y) return;
            if (_positions[pos] != null) return;
            _positions.Add(pos, unit);
        }
        
        public void RemoveAt(Position pos)
        {
            if (MaxPosition.x < pos.x || MaxPosition.y < pos.y) return;
            _positions.Remove(pos);
        }

        public void Remove(int id)
        {
            foreach (var pos in _positions.Keys.ToList().Where(pos => _positions[pos].UnitId == id))
            {
                _positions.Remove(pos);
            }
        }
    }
}