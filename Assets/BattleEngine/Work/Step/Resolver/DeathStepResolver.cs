using System.Collections.Generic;
using BattleEngine.Work.Event;
using BattleEngine.Work.Step.Target;
using BattleEngine.Work.Step.UnitStateStep;
using NUnit.Framework;

namespace BattleEngine.Work.Step.Resolver
{
    public class DeathStepResolver : IStepResolver<DeathStep>
    {
        public List<IExecutable> Resolve(DeathStep step, BattleState state)
        {
            Assert.IsInstanceOf<IdTarget>(step.Target);
            var exec = new List<IExecutable>();
            
            var target = state.GetUnit(((IdTarget)step.Target).Id);
            if (target == null) return exec;
            
            exec.Add(new DeathEvent(
                target.UnitId,
                target.Stats.Type.ToString()
                ));
            
            return exec;
        }
    }
}