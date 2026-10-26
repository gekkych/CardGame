using BattleEngine.Id.DefId;

namespace BattleEngine.Cards.Card
{
    public static class UnitCardLibrary
    {
        public static BaseUnitCard HealerCard()
        {
            return new BaseUnitCard(2, UnitDef.Healer);
        }
    }
}