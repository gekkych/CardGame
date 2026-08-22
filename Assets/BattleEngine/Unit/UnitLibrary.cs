using BattleEngine.Enums;
using BattleEngine.Unit.Component.UnitAbilityCompTags;

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

        public static BaseUnit Healer()
        {
            
            var stats = new UnitStats(
                UnitType.Healer,
                5,
                0);
            var state = UnitState.FromStats(stats);
            BaseUnit healer = new(UnitIdGenerator.Get(), stats, state);
            
            healer.AddComp(new HealerComp(1));
            
            return healer;
        }
        
    }
}