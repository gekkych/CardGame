namespace BattleEngine.Battler
{
    public abstract class BaseBattler
    {
        public BattlerData BattlerData { get; set; }

        public bool IsDead()
        {
            return BattlerData.Shield <= 0;
        }
    }
}