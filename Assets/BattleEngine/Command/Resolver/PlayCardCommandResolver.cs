using System;
using System.Collections.Generic;
using BattleEngine.Enums;
using BattleEngine.Id.DefId;
using BattleEngine.State;
using BattleEngine.Work.Step;
using BattleEngine.Work.Step.Interfaces;
using BattleEngine.Work.Step.Target;
using BattleEngine.Work.Step.UnitStateStep;

namespace BattleEngine.Command.Resolver
{
    public class PlayCardCommandResolver : ICommandResolver<PlayCardContext>
    {
        public List<BaseStep> Resolve(BattleState state, PlayCardContext ctx)
        {
            var steps = new List<BaseStep>();

            if (ctx.Card == null  ||
                ctx.Card.Cost < 0 ||
                !Enum.IsDefined(typeof(UnitDef), ctx.Card.UnitToPlace)) return steps;
            
            if (!state.Board.InBounds(ctx.Position)) return steps;

            var battler = state.GetBattler(ctx.ID);
            if (battler == null || battler.IsDead()) return steps;
            if (battler.BattlerData.Shield < ctx.Card.Cost) return steps;
            
            steps.Add(new PlaceUnitStep(ctx.Card.UnitToPlace, ctx.Position)
            {
                Priority = 1
            });
            
            steps.Add(new DamageStep(ctx.ID, new IdTarget(ctx.ID), ctx.Card.Cost, DamageSource.CardCost)
            {
                Priority = 1
            });
            
            return steps;
        }
    }
}
