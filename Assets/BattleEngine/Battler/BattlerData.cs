using BattleEngine.Id;
using BattleEngine.Id.RuntimeId;

namespace BattleEngine.Battler
{
    public class BattlerData
    {
        public BattlerData(IdProvider provider, BattlerType battlerType, int maxShield)
        {
            BattlerId = provider.NextBattlerId();
            Type = battlerType;
            MaxShield = maxShield;
            Shield = maxShield;
        }
        //ident
        public BattlerId BattlerId { get; set; }
        public BattlerType Type { get; set; }
        
        //curr
        public int Shield { get; set; }
        
        //base
        public int MaxShield { get; set; }
    }
}