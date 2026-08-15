using System.Collections.Generic;
using BattleEngine.Enums;
using BattleEngine.Unit.Component;
using BattleEngine.Work.Event;
using BattleEngine.Work.Step;
using BattleEngine.Work.Step.ComponentStep;

namespace BattleEngine.Reaction
{
    public class RageOnDamageR : BaseReaction
    {
        public RageOnDamageR() => Priority = 20_000;

        public override List<BaseStep> React(BaseEvent e, BattleState state)
        {
            var steps = new List<BaseStep>();
            
            if (e is DamageEvent de)
            {
                var target =  state.GetUnit(de.Target);
                if (target == null)  return steps;

                if (target.HasComp(ComponentName.RageOnDamage))
                {
                    var rage = (RageOnDamageComp)target.GetComp(ComponentName.RageOnDamage);
                    steps.Add(new BonusChangeStep(
                        de.Target,
                        StatsBonuses.Strength,
                        rage.StrengthAmount
                        ));
                }
            }
            
            if (e is EndTurnEvent ete)
            {
                var targets = state.GetAllUnits();

                foreach (var target in targets)
                {
                    if (target.HasComp(ComponentName.RageOnDamage))
                    {
                        var comp = (RageOnDamageComp)target.GetComp(ComponentName.RageOnDamage);
                        if (comp.RemainingTurns > 1)
                        {
                            steps.Add(new ReplaceCompStep(
                                target.UnitId,
                                ComponentName.RageOnDamage,
                                comp with{RemainingTurns = comp.RemainingTurns - 1}));
                        }
                        else
                        {
                            steps.Add(new RemoveCompStep(
                                target.UnitId,
                                ComponentName.Thorn));
                        }
                    }
                }
            }
            
            return steps;
        }

        public override void NewRootStep() { }

        public override void NewTurn() { }
    }
}