using BattleEngine.Unit.Component;

namespace BattleEngine.Work.Event.ComponentEvent
{
    public record RemoveCompEvent(
        int Target,
        string TargetName,
        ComponentName ComponentName,
        BaseComponent Removed
        ) : BaseEvent;
}