using System.Collections.Generic;

namespace BattleEngine
{
    public class BattleContext
    {
        public Turn Turn { get; set; }
        public Battler Player { get; set; }
        public List<Battler> Enemies { get; set; } = new();
        public Board Board { get; set; }
    }
}