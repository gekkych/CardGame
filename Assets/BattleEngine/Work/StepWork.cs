using BattleEngine.Work.Step.Interfaces;

namespace BattleEngine.Work
{
    public record StepWork(BaseStep Step, int Depth) : WorkItem
    {
        public override string ToString()
        {
            return $"StepWork(" +
                   $"Step={Step}, " +
                   $"Depth={Depth}," +
                   $"Priority={Priority})";
        }
    }
}