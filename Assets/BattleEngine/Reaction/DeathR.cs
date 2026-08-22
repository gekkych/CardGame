using System.Collections.Generic;
using BattleEngine.Work.Event;
using BattleEngine.Work.Step;
using BattleEngine.Work.Step.Interfaces;
using BattleEngine.Work.Step.Target;
using BattleEngine.Work.Step.UnitStateStep;

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
                    reactions.Add(new DeathStep(new IdTarget(de.Target)));
                }
            }
            
            return reactions;
        }

        public override void NewRootStep() {}

        public override void NewTurn() {}
    }
}