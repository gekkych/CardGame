using BattleEngine.Enums;
using BattleEngine.Unit.Component;
using BattleEngine.Work.Step.Interfaces;
using BattleEngine.Work.Step.Target;

namespace BattleEngine.Work.Step.CompStep
{
    public record ReplaceCompStep(
        ITarget Target,
        ComponentName ToReplace,
        BaseComponent Relacement
    ) : BaseStep, IStepWithTarget
    {
        public ITarget GetTarget()
        {
            return Target;
        }

        public IStepWithTarget WithTarget(ITarget target)
        {
            return this with { Target = target };
        }
    }
}