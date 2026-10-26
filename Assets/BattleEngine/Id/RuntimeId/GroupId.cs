using BattleEngine.Enums;

namespace BattleEngine.Id.RuntimeId
{
    public class GroupId : UnionIdWrapper
    {
        public GroupId(int id) : base(IdType.Group, id) {}

        public GroupId() {}

        public static GroupId Placeholder => new(-1);
    }
}