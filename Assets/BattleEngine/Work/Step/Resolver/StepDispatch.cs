using System.Collections.Generic;
using BattleEngine.Work.Event;

namespace BattleEngine.Work.Step.Resolver
{
    public static class StepDispatch
    {
        public static List<BaseEvent> Resolve(BaseStep step, BattleState state)
        {
            return step switch
            {
                DamageStep damageStep =>
                    new DamageStepResolver().Resolve(damageStep, state),

                DeathStep deathStep =>
                    new DeathStepResolver().Resolve(deathStep, state),

                _ => new List<BaseEvent>()
            };
        }
    }
}