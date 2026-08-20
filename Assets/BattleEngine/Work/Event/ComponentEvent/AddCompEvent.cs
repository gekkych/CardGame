using BattleEngine.Enums;
using BattleEngine.Unit.Component;

namespace BattleEngine.Work.Event.ComponentEvent
{
    public record AddCompEvent(
        int Target,
        string TargetName,
        ComponentName ComponentName,
        BaseComponent Added
        ) : BaseEvent;
}