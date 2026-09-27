using BattleEngine.Enums;
using BattleEngine.Id.RuntimeId;
using BattleEngine.Unit.Component;

namespace BattleEngine.Work.Event.ComponentEvent
{
    public record ReplaceCompEvent(
        UnitId Target,
        string TargetName,
        ComponentName ToReplace,
        BaseComponent OldComponent,
        BaseComponent NewComponent
        ) : BaseEvent;
}