using BattleEngine.Work.Step.Interfaces;
using BattleEngine.Work.Step.Target;

//#TODO ADD RESOLVER+CALCULATOR
namespace BattleEngine.Work.Step.UnitStateStep
{
    public record HealStep(
        int Healer,
        ITarget Target,
        int Amount
    ) : BaseStep, IStepWithTarget, IStepWithPerformer
  
    {
        public ITarget GetTarget() => Target;
        public IStepWithTarget WithTarget(ITarget target) => this with{Target = target};
        public IStepWithPerformer WithFrom(int from) => this with{Amount = from};
    }
}