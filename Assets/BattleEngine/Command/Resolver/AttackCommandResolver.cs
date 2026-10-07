using System.Collections.Generic;
using BattleEngine.Work.Step.Interfaces;

namespace BattleEngine.Command.Resolver
{
    public class AttackCommandResolver : ICommandResolver<AttackContext>
    {
        public List<BaseStep> Resolve(BattleState state, AttackContext ctx)
        {
            var attacker = state.GetUnitAt(ctx.FromPos);
            var target = state.GetUnitAt(ctx.ToPos);
            
            if (ctx.AttackerShouldExists && attacker == null || 
                ctx.TargetShouldExists   && target   == null)
            {
                return new List<BaseStep>();
            }

            var steps = new List<BaseStep>();
            foreach (var step in ctx.Attack.Steps)
            {
                var bound = step;

                if (bound is IStepWithTarget swt && swt.GetTarget() is ITargetPosOffset pt)
                    bound = (BaseStep)swt.WithTarget(pt.Offset(ctx.ToPos));
                
                if (bound is IStepWithPerformer swp)
                    bound = (BaseStep)swp.WithFrom(attacker.UnitId.Raw);

                steps.Add(bound);
            }
            return steps;
        }
    }
}