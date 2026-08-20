using System.Collections.Generic;
using BattleEngine.Work.Step;
using BattleEngine.Work.Step.Target;
using BattleEngine.Work.Step.UnitStateStep;

namespace BattleEngine.Command.Resolver
{
    public class AttackCommandResolver : ICommandResolver<AttackContext>
    {
        public List<BaseStep> Resolve(BattleState state, AttackContext ctx)
        {
            if (state.GetUnitAt(ctx.ToPos) == null) return null; //TODO error
            if (state.GetUnitAt(ctx.FromPos) == null) return null; //TODO error
            
            var steps = new List<BaseStep>();
            
            //bake ctx #TODO MAKE IT NORMAL
            foreach (BaseStep step in ctx.Attack.Steps)
            {
                switch (step)
                {
                    case DamageStep damage:                  
                        steps.Add(damage with
                        {
                            Attacker = state.GetUnitAt(ctx.FromPos).UnitId,
                            Target = (damage.Target is PosTarget pt) ? new PosTarget(pt.Pos + ctx.ToPos) : damage.Target
                        });
                        break;
                    
                    default:
                        steps.Add(step);
                        break;
                }
            }
            
            return  steps;
        }
    }
}