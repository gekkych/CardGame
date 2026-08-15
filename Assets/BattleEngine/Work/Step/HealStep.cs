namespace BattleEngine.Work.Step
{
    public record HealStep(
        int Amount,
        int To
        ) : BaseStep;
}