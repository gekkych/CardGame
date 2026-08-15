using System;
using System.Collections.Generic;
using BattleEngine.Work.Event;

namespace BattleEngine.Work.Step.Resolver
{
    public class HealStepResolver : IStepResolver<HealStep>
    {
        public List<IExecutable> Resolve(HealStep step, BattleState state)
        {
            var events = new List<IExecutable>();
            
            var target = state.GetUnit(step.To);
            if (target == null) return events;

            int heal = step.Amount;
            heal = Math.Min(heal, target.Stats.MaxHealth - target.State.CurrHp);
            
            if (heal == 0) return events;
            
            events.Add(new HealEvent(
                heal,
                step.To,
                target.Stats.Type.ToString(),
                target.State.CurrHp,
                target.State.CurrHp + heal));
            return events;
        }
    }
}