using BattleEngine.Enums;

namespace BattleEngine.Id.RuntimeId
{
    public class BattlerId : UnionIdWrapper
    {
        public BattlerId(int id) : base(IdType.Battler, id) {}
        public BattlerId() {}
    }
}