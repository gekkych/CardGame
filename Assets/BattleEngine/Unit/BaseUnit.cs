using System.Collections.Generic;
using BattleEngine.Unit.Component;

namespace BattleEngine.Unit
{
    public class BaseUnit
    {
        public int UnitId { get; set; }
        public UnitStats  Stats { get; set; }
        public UnitState State { get; set; }

        public List<BaseComponent> Comps = new();

        public BaseUnit(int id, UnitStats stats, UnitState state)
        {
            this.UnitId = id;
            this.Stats = stats;
            this.State = state;
        }

        public bool HasComp<TComp>() where TComp : BaseComponent
        {
            foreach (BaseComponent comp in Comps)
            {
                if (comp is TComp) { return true; }
            }
            return false;
        }

        public bool IsDead()
        {
            return State.CurrHp <= 0;
        }
    }
}