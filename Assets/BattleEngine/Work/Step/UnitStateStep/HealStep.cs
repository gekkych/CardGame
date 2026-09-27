using BattleEngine.Id;
using BattleEngine.Work.Step.Interfaces;
using BattleEngine.Work.Step.Target;

namespace BattleEngine.Work.Step.UnitStateStep
{
    public record HealStep(
        IdUnion Healer,
        ITarget Target,
        int Amount
    ) : BaseStep, IStepWithTarget, IStepWithPerformer
  
    {
        public ITarget GetTarget() => Target;
        public IStepWithTarget WithTarget(ITarget target) => this with{Target = target};
        public IStepWithPerformer WithFrom(IdUnion from) => this with{Healer = from};
    }
}