namespace BattleEngine.Battler
{
    public class BaseBattler
    {
        public BattlerData BattlerData { get; set; }

        public BaseBattler(BattlerData data)
        {
            BattlerData = data;
        }

        public bool IsDead()
        {
            return BattlerData.Shield <= 0;
        }
    }
}