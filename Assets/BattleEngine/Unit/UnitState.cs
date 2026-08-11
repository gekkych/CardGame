namespace BattleEngine.Unit
{
    public class UnitState
    {
        public int CurrHp;
        
        public UnitState(int hp)
        {
            this.CurrHp = hp;
        }
        public static UnitState FromStats(UnitStats stats)
        {
            return new UnitState(stats.MaxHealth);
        }
    }
}