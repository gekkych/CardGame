using System.Collections.Generic;
using BattleEngine.Enums;
using BattleEngine.Unit.Component;
using BattleEngine.Work.Event;
using BattleEngine.Work.Step;

namespace BattleEngine.Reaction
{
    public class ThornRSystem : BaseReaction
    {
        private HashSet<int> _alreadyHit = new();

        public ThornRSystem() => Priority = 1000;
        public override List<BaseStep> React(BaseEvent e, BattleState state)
        {
            List<BaseStep> steps = new();
            if (e is DamageEvent de)
            {
                if (de.Source == DamageSource.Thorn) return steps; 
                var from = state.GetUnit(de.Attacker);
                if (from == null) return steps;
                
                var to = state.GetUnit(de.Target);
                if (to == null) return steps;

                if (to.HasComp(Comps.Thorn) && !_alreadyHit.Contains(from.UnitId))
                {
                    _alreadyHit.Add(from.UnitId);
                    steps.Add(new DamageStep(Amount:5, From: de.Target, To: de.Attacker, Source:DamageSource.Thorn));
                }
                return steps;
                
            }
            return steps;
            
        }

        public override void NewRootStep() => _alreadyHit.Clear();

        public override void NewTurn() {}
    }
}