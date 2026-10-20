using System.Collections.Generic;
using BattleEngine.Id.RuntimeId;
using BattleEngine.State;
using BattleEngine.Work.Event;
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
                bool isDead = false;
                if (de.Target.To<UnitId>(out var unitId))
                    isDead = state.GetUnit(unitId)?.IsDead() ?? false;
                if (de.Target.To<BattlerId>(out var battlerId))
                    isDead = state.GetBattler(battlerId)?.IsDead() ?? false;

                if (isDead)
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