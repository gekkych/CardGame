using BattleEngine.Work.Step.Interfaces;
using BattleEngine.Work.Step.Target;

namespace BattleEngine.Work.Step.UnitStateStep
{
    public record DeathStep(
        ITarget Target
        ) : BaseStep, IStepWithTarget
    {
        public ITarget GetTarget()
        {
            return Target;
        }

        public IStepWithTarget WithTarget(ITarget target)
        {
            return this with{Target = target};
        }
    }
}