using BattleEngine.Work.Step;

namespace BattleEngine.Work
{
    public record StepWork(BaseStep Step, int Depth) : WorkItem;
}