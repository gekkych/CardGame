using System.Collections.Generic;
using BattleEngine.Work.Event;

namespace BattleEngine.Work.Step.Resolver
{
    public class BonusChangeStepResolver : IStepResolver<BonusChangeStep>
    {
        public List<IExecutable> Resolve(BonusChangeStep step, BattleState state)
        {
            var events = new List<IExecutable>();
            var target = state.GetUnit(step.Id);
            
            if (target == null)  return events;
            
            events.Add(new BonusChangeEvent(
                step.Id,
                target.Stats.Type.ToString(),
                step.Bonus,
                step.Delta));
            
            return events;
        }
    }
}