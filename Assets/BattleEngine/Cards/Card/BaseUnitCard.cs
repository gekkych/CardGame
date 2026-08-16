using BattleEngine.Unit;

namespace BattleEngine.Cards.Card
{
    public class BaseUnitCard
    {
        public int Cost { get; set; }
        public BaseUnit UnitToPlace { get; set; }
    }
}