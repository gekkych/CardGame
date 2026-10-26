using BattleEngine.Id;

namespace BattleEngine.Work.Step.Interfaces
{
    public interface IStepWithPerformer
    {
        IStepWithPerformer WithFrom(IdUnion from);
    }
}