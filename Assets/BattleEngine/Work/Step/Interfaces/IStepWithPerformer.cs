using BattleEngine.Id;
using BattleEngine.Id.RuntimeId;

namespace BattleEngine.Work.Step.Interfaces
{
    public interface IStepWithPerformer
    {
        IStepWithPerformer WithFrom(IdUnion from);
    }
}