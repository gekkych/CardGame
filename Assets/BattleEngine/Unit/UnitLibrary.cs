using BattleEngine.Enums;

namespace BattleEngine.Unit
{
    public static class UnitLibrary
    {
        
        public static BaseUnit Slime()
        {
            var stats = new UnitStats(
                UnitType.Slime,
                15,
                0);
            var state = UnitState.FromStats(stats);
            
            return new BaseUnit(UnitIdGenerator.Get(), stats, state);
        }
        
        public static BaseUnit Warrior()
        {
            var stats = new UnitStats(
                UnitType.Warrior,
                60,
                0);
            var state = UnitState.FromStats(stats);
            
            return new BaseUnit(UnitIdGenerator.Get(), stats, state);
        }
        
    }
}