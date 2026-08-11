using BattleEngine.Enums;

namespace BattleEngine.Unit
{
    public static class UnitLibrary
    {
        private static int _counter = 0;
        public static BaseUnit Slime()
        {
            var stats = new UnitStats(UnitType.Slime, 15);
            var state = UnitState.FromStats(stats);
            int id = _counter++;
            
            return new BaseUnit(id, stats, state);
        }
        
        public static BaseUnit Warrior()
        {
            var stats = new UnitStats(UnitType.Warrior, 60);
            var state = UnitState.FromStats(stats);
            int id = _counter++;
            
            return new BaseUnit(id, stats, state);
        }
        
    }
}