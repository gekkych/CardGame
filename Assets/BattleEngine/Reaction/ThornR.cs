using System.Collections.Generic;
using BattleEngine.Enums;
using BattleEngine.Unit.Component;
using BattleEngine.Work.Event;
using BattleEngine.Work.Step;
using BattleEngine.Work.Step.ComponentStep;

namespace BattleEngine.Reaction
{
    public class ThornR : BaseReaction
    {
        private Dictionary<int, HashSet<int>> _alreadyhit = new(); 

        public ThornR() => Priority = 1000;
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

                if (!to.HasComp(ComponentName.Thorn)) return steps;

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

            if (e is EndTurnEvent ete)
            {
                var targets = state.GetAllUnits();

                foreach (var target in targets)
                {
                    if (target.HasComp(ComponentName.Thorn))
                    {
                        var comp = (ThornComp)target.GetComp(ComponentName.Thorn);
                        if (comp.RemainingTurns > 1)
                        {
                            steps.Add(new ReplaceCompStep(
                                target.UnitId,
                                ComponentName.Thorn,
                                comp with{RemainingTurns = comp.RemainingTurns - 1}));
                        }
                        else
                        {
                            steps.Add(new RemoveCompStep(
                                target.UnitId,
                                ComponentName.Thorn));
                        }
                    }
                }
            }
            
            return steps;
            
        }

        public override void NewRootStep() => _alreadyhit.Clear();

        public override void NewTurn() {}
    }
}