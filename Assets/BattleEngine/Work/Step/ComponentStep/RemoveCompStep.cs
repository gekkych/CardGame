using BattleEngine.Unit.Component;

namespace BattleEngine.Work.Step.ComponentStep
{
    public record RemoveCompStep(
        int Target,
        ComponentName ComponentName
        ) : BaseStep;
}