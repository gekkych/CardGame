using System.Collections.Generic;
using BattleEngine.State;
using BattleEngine.Unit;
using BattleEngine.Work.Event;

namespace BattleEngine.Work.Step.Resolver
{
    public class PlaceUnitStepResolver : IStepResolver<PlaceUnitStep>
    {
        public List<IExecutable> Resolve(PlaceUnitStep step, BattleState state)
        {
            var events = new List<IExecutable>();
            if(!state.Board.InBounds(step.Position)) return events;
            if(state.Board.GetUnitAt(step.Position) != null) return events;

            var unit = UnitLibrary.Create(step.UnitToPlace, state.IdProvider);
            events.Add(new PlaceUnitEvent(unit, step.Position));
            
            return events;
        }
    }
}