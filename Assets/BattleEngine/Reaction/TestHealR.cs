using System;
using System.Collections.Generic;
using BattleEngine.Work.Event;
using BattleEngine.Work.Step;

namespace BattleEngine.Reaction
{
    public class TestHealR : BaseReaction
    {
        public TestHealR() => Priority = 1300;

        public override List<BaseStep> React(BaseEvent e, BattleState state)
        {
            var steps = new List<BaseStep>();
            
            if (e is EndTurnEvent)
            {
                var units = state.GetAllUnits();

                foreach (var unit in units)
                {
                    steps.Add(new HealStep(2, unit.UnitId));
                }
            }
            
            return steps;
        }

        public override void NewRootStep()
        {
        }

        public override void NewTurn()
        {
        }
    }
}