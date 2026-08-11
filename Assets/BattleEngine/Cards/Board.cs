using BattleEngine.Unit;

namespace BattleEngine.Cards
{
    //test board
    public class Board
    {
        public BaseUnit Good;
        public BaseUnit Bad;

        public Board()
        {
            Good = UnitLibrary.Warrior();
            Bad = UnitLibrary.Slime();
        }

        public void Remove(int id)
        {
            if (id == Good.UnitId) Good = null;
            if (id == Bad.UnitId) Bad = null;
        }
    }
}