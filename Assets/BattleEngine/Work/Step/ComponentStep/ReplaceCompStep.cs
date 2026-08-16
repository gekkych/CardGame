using BattleEngine.Enums;
using BattleEngine.Unit.Component;

namespace BattleEngine.Work.Step.ComponentStep
{
    public record ReplaceCompStep(
        int Target,
        ComponentName ToReplace,
        BaseComponent Relacement
        ) : BaseStep;
}