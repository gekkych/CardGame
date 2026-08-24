using System.Collections.Generic;
using BattleEngine.Work.Step.Interfaces;
using BattleEngine.Work.Step.Target;

namespace BattleEngine.Command.Resolver
{
    public class AttackCommandResolver : ICommandResolver<AttackContext>
    {
        public List<BaseStep> Resolve(BattleState state, AttackContext ctx)
        {
            var attacker = state.GetUnitAt(ctx.FromPos);
            var target = state.GetUnitAt(ctx.ToPos);
            if (attacker == null || target == null)
                return new List<BaseStep>();

            var steps = new List<BaseStep>();
            foreach (var step in ctx.Attack.Steps)
            {
                var bound = step;

                if (bound is IStepWithTarget swt && swt.GetTarget() is PosTarget pt)
                    bound = (BaseStep)swt.WithTarget(new PosTarget(pt.Pos + ctx.ToPos));
                
                if (bound is IStepWithPerformer swp)
                    bound = (BaseStep)swp.WithFrom(attacker.UnitId);

                steps.Add(bound);
            }
            return steps;
        }
    }
}