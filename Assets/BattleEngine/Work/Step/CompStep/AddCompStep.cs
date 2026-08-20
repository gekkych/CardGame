using BattleEngine.Unit.Component;
using BattleEngine.Work.Step.Target;

namespace BattleEngine.Work.Step.CompStep
{
    public record AddCompStep(
        ITarget Target,
        BaseComponent Component
        ) : BaseStep, IStepWithTarget
    {
        public ITarget GetTarget()
        {
            return Target;
        }

        public IStepWithTarget ChangeTarget(ITarget target)
        {
            return this with {Target = target};
        }
    }
}