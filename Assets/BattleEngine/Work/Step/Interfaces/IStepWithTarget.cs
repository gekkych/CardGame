using BattleEngine.Work.Step.Target;

namespace BattleEngine.Work.Step.Interfaces
{
    public interface IStepWithTarget
    {
        public ITarget GetTarget();
        public IStepWithTarget WithTarget(ITarget target);
    }
}