using System.Collections.Generic;
using System.Linq;
using BattleEngine.Cards;
using BattleEngine.Enums;
using BattleEngine.Unit.Component.UnitAbilityCompTags;
using BattleEngine.Work.Event;
using BattleEngine.Work.Step.Interfaces;
using BattleEngine.Work.Step.Target;
using BattleEngine.Work.Step.UnitStateStep;

namespace BattleEngine.Reaction.UnitReaction
{
    public class HealerUnitR : BaseReaction
    {
        public HealerUnitR() => Priority = 10_500;
        private const int Mult = 2;

        public override List<BaseStep> React(BaseEvent e, BattleState state)
        {
            var steps = new List<BaseStep>();
            
            if (e is not EndTurnEvent) return steps;
            
            var healers = state.GetAllUnits()?.Where(u => u.HasComp(ComponentName.HealerUnit));

            if (healers == null) return steps;
            
            foreach (var h in healers)
            {
                var maybePos = state.Board.GetPosition(h);
                if (maybePos is not { } pos) continue;
                int healAmount = ((HealerUnitComp)h.GetComp(ComponentName.HealerUnit)).Amount;
                bool hasHealerNeighbor = state
                    .GetUnitsInPattern(pos, Pattern.Patterns.Neighbors())?
                    .Any(u => u.HasComp(ComponentName.HealerUnit)) ?? false;

                if (hasHealerNeighbor) healAmount *= Mult;
                steps.Add(new HealStep(
                    h.UnitId,
                    new IdTarget(h.UnitId), 
                    healAmount));
            }
            return steps;
        }

        public override void NewRootStep()
        {
        }

        public override void NewTurn()
        {
        }
    }
}