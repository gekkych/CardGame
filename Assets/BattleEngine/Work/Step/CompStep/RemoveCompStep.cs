using BattleEngine.Enums;
using BattleEngine.Work.Step.Interfaces;
using BattleEngine.Work.Step.Target;

namespace BattleEngine.Work.Step.CompStep
{
    public record RemoveCompStep(
        ITarget Target,
        ComponentName ComponentName
    ) : BaseStep, IStepWithTarget
    {
        
        public ITarget GetTarget() => Target;
        public IStepWithTarget WithTarget(ITarget target) => this with { Target = target };
    }
}