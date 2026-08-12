using System.Collections.Generic;
using BattleEngine.Enums;
using BattleEngine.Unit.Component;
using BattleEngine.Work.Event;
using BattleEngine.Work.Step;

namespace BattleEngine.Reaction
{
    public class RageOnDamageRSystem : BaseReaction
    {
        public RageOnDamageRSystem() => Priority = 20_000;

        public override List<BaseStep> React(BaseEvent e, BattleState state)
        {
            var reactions = new List<BaseStep>();
            
            if (e is DamageEvent de)
            {
                var target =  state.GetUnit(de.Target);
                if (target == null)  return reactions;

                if (target.HasComp<RageOnDamageComp>())
                {
                    var rage = target.GetComp<RageOnDamageComp>();
                    reactions.Add(new BonusChangeStep(
                        de.Target,
                        StatsBonuses.Strength,
                        rage.StrengthAmount
                        ));
                }
            }
            return reactions;
        }

        public override void NewRootStep() { }

        public override void NewTurn() { }
    }
}