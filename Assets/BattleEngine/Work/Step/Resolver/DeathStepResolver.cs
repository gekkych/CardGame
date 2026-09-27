using System;
using System.Collections.Generic;
using BattleEngine.Id.RuntimeId;
using BattleEngine.Work.Event;
using BattleEngine.Work.Step.Target;
using BattleEngine.Work.Step.UnitStateStep;

namespace BattleEngine.Work.Step.Resolver
{
    public class DeathStepResolver : IStepResolver<DeathStep>
    {
        public List<IExecutable> Resolve(DeathStep step, BattleState state)
        {
            var exec = new List<IExecutable>();

            if (!((IdTarget)step.Target).Id.To<UnitId>(out var targetId)) throw new NotImplementedException();
            var target = state.GetUnit(targetId);
            if (target == null) return exec;
            
            exec.Add(new DeathEvent(
                target.UnitId.Raw,
                target.Stats.Type.ToString()
                ));
            
            return exec;
        }
    }
}