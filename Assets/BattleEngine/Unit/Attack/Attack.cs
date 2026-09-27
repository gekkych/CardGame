using System.Collections.Generic;
using BattleEngine.Id.DefId;
using BattleEngine.Work.Step.Interfaces;

namespace BattleEngine.Unit.Attack
{
    public class Attack
    {
        public AttackDef ID { get; set; }
        public List<BaseStep> Steps { get; set; } = new();
    }
}