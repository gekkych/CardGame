using BattleEngine.Enums;
using BattleEngine.Id.RuntimeId;

namespace BattleEngine.Id
{
    public class IdProvider
    {
        private int _nextId;
        
        public int CurrentId => _nextId;
        public int NextId => ++_nextId;

        public IdProvider(int start)
        {
            _nextId = start;
        }
        
        //DefId
        
        //RuntimeId
        public IdUnion NextIdIdUnion(IdType type) => new(type, NextId);
        public UnitId NextUnitId() => new(NextId);
        public BattlerId NextBattlerId() => new(NextId);
        public CardId NextCardId() => new(NextId);
        public AttackId NextAttackId() => new(NextId);
        
    }
    
    
}