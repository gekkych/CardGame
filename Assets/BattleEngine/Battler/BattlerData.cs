namespace BattleEngine.Battler
{
    public record BattlerData
    {
        //ident
        public int BattlerId { get; set; }
        public BattlerType Type { get; set; }
        
        //curr
        public int Shield { get; set; }
        
        //base
        public int MaxShield { get; set; }
    }
}