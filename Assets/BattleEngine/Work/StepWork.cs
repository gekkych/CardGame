using BattleEngine.Work.Step;
using BattleEngine.Work.Step.Interfaces;

namespace BattleEngine.Work
{
    public record StepWork(BaseStep Step, int Depth) : WorkItem;
}