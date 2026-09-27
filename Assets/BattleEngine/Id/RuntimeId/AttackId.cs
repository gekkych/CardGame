using BattleEngine.Enums;

namespace BattleEngine.Id.RuntimeId
{
    public class AttackId : UnionIdWrapper
    {
        public AttackId(int id) : base(IdType.Attack, id) {}
        public AttackId() {}
    }
}