using BattleEngine.Enums;
using BattleEngine.Id;
using BattleEngine.Id.DefId;
using BattleEngine.Unit.Component.UnitAbilityCompTags;

namespace BattleEngine.Unit
{
    public static class UnitLibrary
    {
        
        public static BaseUnit Slime(IdProvider provider)
        {
            var stats = new UnitStats(
                UnitDef.Slime,
                15,
                0);
            var state = UnitState.FromStats(stats);
            
            return new BaseUnit(provider.NextUnitId(), stats, state);
        }
        
        public static BaseUnit Warrior(IdProvider provider)
        {
            var stats = new UnitStats(
                UnitDef.Warrior,
                60,
                0);
            var state = UnitState.FromStats(stats);
            
            return new BaseUnit(provider.NextUnitId(), stats, state);
        }

        public static BaseUnit Healer(IdProvider provider)
        {
            
            var stats = new UnitStats(
                UnitDef.Healer,
                5,
                0);
            var state = UnitState.FromStats(stats);
            BaseUnit healer = new(provider.NextUnitId(), stats, state);
            
            healer.AddComp(new HealerUnitComp(1));
            
            return healer;
        }
        
    }
}