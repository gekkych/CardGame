using System;
using System.Collections.Generic;
using BattleEngine.Work.Event;
using BattleEngine.Work.Event.ComponentEvent;
using BattleEngine.Work.Step.ComponentStep;

namespace BattleEngine.Work.Step.Resolver
{
    public static class StepDispatch
    {
        public static List<IExecutable> Resolve(BaseStep step, BattleState state)
        {
            return step switch
            {
                DamageStep damageStep =>
                    new DamageStepResolver().Resolve(damageStep, state),
                
                HealStep healStep =>
                    new HealStepResolver().Resolve(healStep, state),

                DeathStep deathStep =>
                    new DeathStepResolver().Resolve(deathStep, state),
                
                BonusChangeStep bonusChangeStep =>
                    new BonusChangeStepResolver().Resolve(bonusChangeStep, state),
                
                RemoveCompStep removeCompStep =>
                    new RemoveCompStepResolver().Resolve(removeCompStep, state),
                
                ReplaceCompStep replaceCompStep =>
                    new ReplaceCompStepResolver().Resolve(replaceCompStep, state),

                _ => throw new NotImplementedException()
            };
        }
    }
}