using BattleEngine.Enums;

namespace BattleEngine.Unit
{
    public class UnitState
    {
        public int CurrHp { get; set; }
        public int StrengthBonus { get; set; }
        
        public UnitState(int hp)
        {
            CurrHp = hp;
        }

        public void ChangeBonus(StatsBonuses bonus, int delta)
        {
            switch (bonus)
            {
                case StatsBonuses.Strength:
                    StrengthBonus += delta;
                    break;
            }
        }
        
        public static UnitState FromStats(UnitStats stats)
        {
            return new UnitState(stats.MaxHealth);
        }
    }
}