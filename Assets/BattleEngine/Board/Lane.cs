using BattleEngine;

namespace BattleEngine
{
    //Игровая линия
    //Содержит карту игрока и карту противника
    public class Lane 
    {
        public Card PlayerCard { get; set; }
        public Card OpponentCard { get; set; }
    }
}