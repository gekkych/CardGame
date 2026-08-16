using BattleEngine.Enums;
using BattleEngine.Unit.Component;

namespace BattleEngine.Work.Event.ComponentEvent
{
    public record ReplaceCompEvent(
        int Target,
        string TargetName,
        ComponentName ToReplace,
        BaseComponent OldComponent,
        BaseComponent NewComponent
        ) : BaseEvent;
}