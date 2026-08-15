using System.Collections.Generic;
using BattleEngine.Calculation;
using BattleEngine.Unit;
using BattleEngine.Work.Event;

namespace BattleEngine.Work.Step.Resolver
{
    public class DamageStepResolver : IStepResolver<DamageStep>
    {
        private DamageCalculator _calculator = new();
        public List<IExecutable> Resolve(DamageStep step, BattleState state)
        {
            var events = new List<IExecutable>();

            var attacker = state.GetUnit(step.From);
            var target = state.GetUnit(step.To);
            if (attacker == null) return events;
            if (target == null) return events;

            var actual = _calculator.Calc(step, state);
            
            events.Add(new DamageEvent(
                step.From, 
                attacker.Stats.Type.ToString(),
                step.To, 
                target.Stats.Type.ToString(),
                actual, 
                step.Source,
                target.State.CurrHp,
                target.State.CurrHp - actual));
            
            return events;

        }
    }
}