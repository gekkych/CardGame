using System.Collections.Generic;
using BattleEngine.Id;
using BattleEngine.Work.Step.Interfaces;

namespace BattleEngine.Work.Step.Target
{
    public static class TargetResolver
    {
        public static List<BaseStep> Resolve(BaseStep step, BattleState state, IdUnion lastId)
        {
            List<BaseStep> steps = new();

            if (step is not IStepWithTarget st || st.GetTarget() is IdTarget) return steps;

            var targets = st.GetTarget().ResolveTarget(state, lastId);
            int prior = targets.ToGroup ? step.Priority + 1 : 0;

            foreach (var target in targets.Ids)
            {
                if (target != null)
                {
                    BaseStep toAdd = (BaseStep)st.WithTarget(new IdTarget(target)) with {Priority = prior};
                    steps.Add(toAdd);
                }
            }
            if (steps.Count == 0) steps.Add(new DummyStep());
            
            return steps;
        }
    }
} 