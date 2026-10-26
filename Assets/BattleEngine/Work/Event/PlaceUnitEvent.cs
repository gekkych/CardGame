using BattleEngine.State;
using BattleEngine.Unit;

namespace BattleEngine.Work.Event
{
    public record PlaceUnitEvent(BaseUnit Unit, Position Position) : BaseEvent;
}