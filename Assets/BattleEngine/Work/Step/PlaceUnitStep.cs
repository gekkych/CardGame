using BattleEngine.Id.DefId;
using BattleEngine.State;
using BattleEngine.Work.Step.Interfaces;

namespace BattleEngine.Work.Step
{
    public record PlaceUnitStep(UnitDef UnitToPlace, Position Position) : BaseStep;
}