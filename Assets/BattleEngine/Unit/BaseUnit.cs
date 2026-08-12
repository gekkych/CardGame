using System.Collections.Generic;
using System.Linq;
using BattleEngine.Unit.Component;

namespace BattleEngine.Unit
{
    public class BaseUnit
    {
        public int UnitId { get; set; }
        public UnitStats  Stats { get; set; }
        public UnitState State { get; set; }

        public List<BaseComponent> comps = new();

        public BaseUnit(int id, UnitStats stats, UnitState state)
        {
            this.UnitId = id;
            this.Stats = stats;
            this.State = state;
        }
        
        
        public bool IsDead()
        {
            return State.CurrHp <= 0;
        }

        public bool HasComp<TComp>() where TComp : BaseComponent
        {
            return comps.OfType<TComp>().Any();
        }

        public void AddComp(BaseComponent comp) 
        {
            comps.Add(comp);
        }
        
        public void RemoveComp<TComp>() where TComp : BaseComponent
        {
            foreach (var comp in comps.ToList())
            {
                if (comp is TComp) { comps.Remove(comp); }
            }
        }

        public TComp GetComp<TComp>() where TComp : BaseComponent
        {
            return comps.OfType<TComp>().FirstOrDefault();
        }
    }
}