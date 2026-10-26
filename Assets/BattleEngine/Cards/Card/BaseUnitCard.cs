using BattleEngine.Id.DefId;

namespace BattleEngine.Cards.Card
{
    public class BaseUnitCard
    {
        public BaseUnitCard(int cost, UnitDef unitDef)
        {
            Cost = cost;
            UnitToPlace = unitDef;
        }
        public int Cost { get; set; }
        public UnitDef UnitToPlace { get; init; }
    }
}