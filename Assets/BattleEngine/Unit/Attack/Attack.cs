using System.Collections.Generic;
using BattleEngine.Work.Step;

namespace BattleEngine.Unit.Attack
{
    public class Attack
    {
        public int ID { get; set; }
        public List<BaseStep> Steps { get; set; } = new();
    }
}