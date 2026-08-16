using BattleEngine.Enums;
using BattleEngine.Unit;

namespace BattleEngine.Cards.Card
{
    public static class UnitCardLibrary
    {
        public static BaseUnitCard HealerCard()
        {
            var card = new BaseUnitCard();
            card.Cost = 2;
            
            UnitStats stats = new UnitStats(UnitType.Healer, 6, 0);
            var u = new BaseUnit(stats);
            
            return card;
        }
        
    }
}