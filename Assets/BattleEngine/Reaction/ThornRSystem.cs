using System.Collections.Generic;
using BattleEngine.Enums;
using BattleEngine.Unit.Component;
using BattleEngine.Work.Event;
using BattleEngine.Work.Step;

namespace BattleEngine.Reaction
{
    public class ThornRSystem : BaseReaction
    {
        private Dictionary<int, HashSet<int>> _alreadyhit = new(); 

        public ThornRSystem() => Priority = 1000;
        public override List<BaseStep> React(BaseEvent e, BattleState state)
        {
            List<BaseStep> steps = new();
            if (e is DamageEvent de)
            {
                if (de.Source == DamageSource.Thorn) return steps; 
                if (de.Attacker == de.Target) return steps;
                var from = state.GetUnit(de.Attacker);
                if (from == null) return steps;
                
                var to = state.GetUnit(de.Target);
                if (to == null) return steps;

                if (!to.HasComp<ThornComp>()) return steps;

                if (!_alreadyhit.ContainsKey(from.UnitId))
                {
                    _alreadyhit.Add(from.UnitId, new HashSet<int>());
                }

                if (_alreadyhit[from.UnitId].Contains(to.UnitId)) return steps;
                
                _alreadyhit[from.UnitId].Add(to.UnitId);
                steps.Add(new DamageStep(
                    Amount: 5,
                    From: de.Target,
                    To: de.Attacker,
                    Source: DamageSource.Thorn));

                return steps;
                
            }
            return steps;
            
        }

        public override void NewRootStep() => _alreadyhit.Clear();

        public override void NewTurn() {}
    }
}