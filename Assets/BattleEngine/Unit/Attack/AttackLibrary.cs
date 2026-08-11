using BattleEngine.Enums;
using BattleEngine.Work.Step;

namespace BattleEngine.Unit.Attack
{
    public static class AttackLibrary
    {
        public static readonly Attack Slash = new()
            {
            ID = 0,
            Steps =
            {
                new DamageStep(Amount: 10, To: -1, From: -1, Source: 0)
            }
            };
        
        public static readonly Attack DoubleSlash = new()
        {
            ID = 0,
            Steps =
            {
                new DamageStep(Amount: 10, To: -1, From: -1, Source: DamageSource.Attack),
                new DamageStep(Amount: 10, To: -1, From: -1, Source: DamageSource.Attack)
            }
        };
    }
}