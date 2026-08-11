using System.Collections.Generic;
using BattleEngine.Work.Step;

namespace BattleEngine.Command.Resolver
{
    public class AttackCommandResolver : ICommandResolver<AttackContext>
    {
        public List<BaseStep> Resolve(BattleState state, AttackContext ctx)
        {
            if (state.GetUnit(ctx.To) == null) return null; //TODO error
            if (state.GetUnit(ctx.From) == null) return null; //TODO error

            var steps = new List<BaseStep>();
            
            //bake ctx
            foreach (BaseStep step in ctx.Attack.Steps)
            {
                if (step is DamageStep damage)
                {
                   steps.Add(damage with {To = ctx.To, From = ctx.From}); 
                }

                if (step is DeathStep death)
                {
                    steps.Add(death with { To = ctx.To });
                }
            }
            
            return  steps;
        }
    }
}