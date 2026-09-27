using System;
using System.Collections.Generic;
using BattleEngine.Calculation;
using BattleEngine.Id.RuntimeId;
using BattleEngine.Work.Event;
using BattleEngine.Work.Step.Target;
using BattleEngine.Work.Step.UnitStateStep;

namespace BattleEngine.Work.Step.Resolver
{
    public class HealStepResolver : IStepResolver<HealStep>
    {
        public List<IExecutable> Resolve(HealStep step, BattleState state)
        {
            var events = new List<IExecutable>();

            if (!step.Healer.To<UnitId>(out var idHealer))                throw new NotImplementedException();
            if (!((IdTarget)step.Target).Id.To<UnitId>(out var idTarget)) throw new NotImplementedException();
            
            var healer = state.GetUnit(idHealer);
            var target = state.GetUnit(idTarget);
            if (healer == null) return events;
            if (target == null) return events;

            var actual = HealCalculator.Calc(step, state);
            
            events.Add(new HealEvent(
                step.Healer, 
                healer.Stats.Type.ToString(),
                target.UnitId.Raw, 
                target.Stats.Type.ToString(),
                actual, 
                target.State.CurrHp,
                target.State.CurrHp + actual));
            
            return events;

        }
    }
}