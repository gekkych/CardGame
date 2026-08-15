using System.Collections.Generic;
using BattleEngine.Work.Event;

namespace BattleEngine.Work.Step.Resolver
{
    public class DeathStepResolver : IStepResolver<DeathStep>
    {
        public List<IExecutable> Resolve(DeathStep step, BattleState state)
        {
            List<IExecutable> events = new();
            var unit = state.GetUnit(step.To);

            if (unit != null)
            {
                events.Add(new DeathEvent(
                    step.To,
                    unit.Stats.Type.ToString()));
            }
            return events;
        }
    }
}