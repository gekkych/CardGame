using System.Collections.Generic;
using System.Linq;
using BattleEngine.Enums;
using BattleEngine.Id;
using BattleEngine.Id.RuntimeId;
using BattleEngine.Unit.Component;

namespace BattleEngine.Unit
{
    public class BaseUnit
    {
        public UnitId UnitId { get; init; }
        public UnitStats  Stats { get; set; }
        public UnitState State { get; set; }

        public List<BaseComponent> comps = new();

        public BaseUnit(UnitStats stats, IdProvider provider)
        {
            UnitId = provider.NextUnitId();
            Stats = stats;
            State = UnitState.FromStats(stats);
        }
        
        public BaseUnit(UnitId id, UnitStats stats, UnitState state)
        {
            UnitId = id;
            Stats = stats;
            State = state;
        }
        
        
        public bool IsDead()
        {
            return State.CurrHp <= 0;
        }

        public bool HasComp(ComponentName name)
        {
            return comps.Any(c => c.Name == name);
        }

        public void AddComp(BaseComponent comp) 
        {
            comps.Add(comp);
        }
        
        public void RemoveComp(ComponentName name)
        {
            foreach (var comp in comps.ToList())
            {
                if (comp.Name == name) { comps.Remove(comp); }
            }
        }

        public BaseComponent GetComp(ComponentName name)
        {
            return comps.FirstOrDefault(c => c.Name == name);
        }
    }
}