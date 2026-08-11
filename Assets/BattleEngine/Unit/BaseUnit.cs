using System.Collections.Generic;
using BattleEngine.Unit.Component;

namespace BattleEngine.Unit
{
    public class BaseUnit
    {
        public int UnitId { get; set; }
        public UnitStats  Stats { get; set; }
        public UnitState State { get; set; }

        public List<Comps> Comps = new();

        public BaseUnit(int Id, UnitStats Stats, UnitState State)
        {
            this.UnitId = Id;
            this.Stats = Stats;
            this.State = State;
        }

        public bool HasComp(Comps comp)
        {
            return Comps.Contains(comp);
        }

        public bool IsDead()
        {
            return State.CurrHp <= 0;
        }
    }
}