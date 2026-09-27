using BattleEngine.Enums;
using BattleEngine.Id;
using BattleEngine.Id.RuntimeId;
using BattleEngine.Work.Step.Interfaces;
using BattleEngine.Work.Step.Target;

namespace BattleEngine.Work.Step.UnitStateStep
{
    public record DamageStep(
        IdUnion Attacker,
        ITarget Target,
        int Amount,
        DamageSource Source
        ) : BaseStep, IStepWithTarget, IStepWithPerformer
  
    {
        public ITarget GetTarget() => Target;
        public IStepWithTarget WithTarget(ITarget target) => this with{Target = target};
        public IStepWithPerformer WithFrom(IdUnion from) => this with{Attacker = from};
    }
}