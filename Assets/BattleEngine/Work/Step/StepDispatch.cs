using System;
using System.Collections.Generic;
using BattleEngine.Work.Step.CompStep;
using BattleEngine.Work.Step.Interfaces;
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
                DamageStep damageStep => new DamageStepResolver().Resolve(damageStep, state),
                HealStep healStep => new HealStepResolver().Resolve(healStep, state),
                DeathStep deathStep => new DeathStepResolver().Resolve(deathStep, state),
                AddCompStep addCompStep => new AddCompStepResolver().Resolve(addCompStep, state),
                RemoveCompStep removeCompStep => new RemoveCompStepResolver().Resolve(removeCompStep, state),
                ReplaceCompStep replaceCompStep => new ReplaceCompStepResolver().Resolve(replaceCompStep, state),
                _ => throw new NotImplementedException()
            };
        }
    }
}