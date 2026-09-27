using BattleEngine.Enums;

namespace BattleEngine.Id.RuntimeId
{
    public class UnitId : UnionIdWrapper
    {
        public UnitId(int id) : base(IdType.Unit, id) {}
        public UnitId() {}
        
        public static UnitId Placeholder => new(-1);
    }
}