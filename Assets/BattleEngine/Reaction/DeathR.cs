using System.Collections.Generic;
using BattleEngine.Work.Event;
using BattleEngine.Work.Step;

namespace BattleEngine.Reaction
{
    public class DeathR : BaseReaction
    {
        public DeathR() => Priority = 1500;
        
        public override List<BaseStep> React(BaseEvent e, BattleState state)
        {
            var reactions = new List<BaseStep>();
            
            if (e is DamageEvent de)
            {
                var unit = state.GetUnit(de.Target);
                if (unit != null && unit.IsDead())
                {
                    reactions.Add(new DeathStep(de.Target));
                }
            }
            
            return reactions;
        }

        public override void NewRootStep() {}

        public override void NewTurn() {}
    }
}