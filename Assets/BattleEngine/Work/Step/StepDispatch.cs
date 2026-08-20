using System;
using System.Collections.Generic;
using BattleEngine.Work.Step.CompStep;
using BattleEngine.Work.Step.Resolver;
using BattleEngine.Work.Step.UnitStateStep;

namespace BattleEngine.Work.Step
{
    public static class StepDispatch
    {
        public static List<IExecutable> Resolve(BaseStep step, BattleState state)
        {
            return step switch
            {
                DummyStep => new List<IExecutable>(),
                DamageStep damageStep => DamageStepResolver.Resolve(damageStep, state),
                DeathStep deathStep => DeathStepResolver.Resolve(deathStep, state),
                AddCompStep addCompStep => AddCompStepResolver.Resolve(addCompStep, state),
                RemoveCompStep removeCompStep => RemoveCompStepResolver.Resolve(removeCompStep, state),
                ReplaceCompStep replaceCompStep => ReplaceCompStepResolver.Resolve(replaceCompStep, state),
                _ => throw new NotImplementedException()
            };
        }
    }
}