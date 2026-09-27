using System.Collections.Generic;
using BattleEngine.Enums;
using BattleEngine.Id.RuntimeId;
using BattleEngine.Unit.Component;
using BattleEngine.Work.Event;
using BattleEngine.Work.Step.Interfaces;
using BattleEngine.Work.Step.Target;
using BattleEngine.Work.Step.UnitStateStep;

namespace BattleEngine.Reaction
{
    public class VampirismR : BaseReaction
    {
        public VampirismR() => Priority = 500;

        public override List<BaseStep> React(BaseEvent e, BattleState state)
        {
            var steps = new List<BaseStep>();

            if (e is DamageEvent de)
            {
                if (de.Attacker == de.Target) return steps;
                if (!de.Attacker.To<UnitId>(out var attackerId)) return steps;
                var from = state.GetUnit(attackerId);
                if (from == null) return steps;
                if (!from.HasComp(ComponentName.Vampirism)) return steps;
                var vampComp = (VampirismComp)from.GetComp(ComponentName.Vampirism);

                steps.Add(new HealStep(
                    from.UnitId.Raw,
                    new IdTarget(from.UnitId.Raw),
                    vampComp.BaseHeal));
            }
            
            return steps;
        }

        public override void NewRootStep() {}

        public override void NewTurn() {}
    }
}