using BattleEngine.Enums;
using BattleEngine.Id.RuntimeId;
using BattleEngine.Unit.Component;

namespace BattleEngine.Work.Event.ComponentEvent
{
    public record RemoveCompEvent(
        UnitId Target,
        string TargetName,
        ComponentName ComponentName,
        BaseComponent Removed
        ) : BaseEvent;
}