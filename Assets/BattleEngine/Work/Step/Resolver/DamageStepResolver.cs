using System;
using System.Collections.Generic;
using BattleEngine.Calculation;
using BattleEngine.Id.RuntimeId;
using BattleEngine.Work.Event;
using BattleEngine.Work.Step.Target;
using BattleEngine.Work.Step.UnitStateStep;

namespace BattleEngine.Work.Step.Resolver
{
    public class DamageStepResolver : IStepResolver<DamageStep>
    {
        public List<IExecutable> Resolve(DamageStep step, BattleState state)
        {
            var events = new List<IExecutable>();

            if (!step.Attacker.To<UnitId>(out var idAttacker))            throw new NotImplementedException();
            if (!((IdTarget)step.Target).Id.To<UnitId>(out var idTarget)) throw new NotImplementedException();
            
            var attacker = state.GetUnit(idAttacker);
            var target = state.GetUnit(idTarget);
            if (attacker == null) return events;
            if (target == null) return events;

            var actual = DamageCalculator.Calc(step, state);
            
            events.Add(new DamageEvent(
                step.Attacker, 
                attacker.Stats.Type.ToString(),
                target.UnitId.Raw, 
                target.Stats.Type.ToString(),
                actual, 
                step.Source,
                target.State.CurrHp,
                target.State.CurrHp - actual));
            
            return events;

        }
    }
}