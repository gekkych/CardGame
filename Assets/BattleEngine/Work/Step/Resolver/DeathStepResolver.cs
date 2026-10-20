using System.Collections.Generic;
using BattleEngine.State;
using BattleEngine.Work.Event;
using BattleEngine.Work.Event.Metadata;
using BattleEngine.Work.Step.Target;
using BattleEngine.Work.Step.UnitStateStep;

namespace BattleEngine.Work.Step.Resolver
{
    public class DeathStepResolver : IStepResolver<DeathStep>
    {
        public List<IExecutable> Resolve(DeathStep step, BattleState state)
        {
            var exec = new List<IExecutable>();

            var targetId = ((IdTarget)step.Target).Id;
            var target = EntityMetadata.FromState(targetId, state);
            if (target == null) return exec;
            
            exec.Add(new DeathEvent(
                targetId,
                new DeathMetadata(target, target.Health, 0)
            ));
            
            return exec;
        }
    }
}