using System.Collections.Generic;
using BattleEngine.Work.Step.Interfaces;

namespace BattleEngine.Work.Step.Target
{
    public static class TargetResolver
    {
        public static List<BaseStep> Resolve(BaseStep step, BattleState state, int lastId)
        {
            List<BaseStep> steps = new();

            if (step is not IStepWithTarget st)
            {
                return steps;
            }
            
            if (st.GetTarget() is IdTarget)
            {
                return steps;
            }

            var targets = st.GetTarget().ResolveTarget(state, lastId);

            foreach (var target in targets)
            {
                if (target != null)
                {
                    steps.Add((BaseStep)st.WithTarget(new IdTarget((int)target)));
                }
            }
            if (steps.Count == 0) steps.Add(new DummyStep());
            
            return steps;
        }
    }
}