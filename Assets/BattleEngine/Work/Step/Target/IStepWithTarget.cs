namespace BattleEngine.Work.Step.Target
{
    public interface IStepWithTarget
    {
        public ITarget GetTarget();
        public IStepWithTarget ChangeTarget(ITarget target);
    }
}