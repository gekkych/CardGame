using BattleEngine.Enums;

namespace BattleEngine.Id.RuntimeId
{
    public class CardId : UnionIdWrapper
    {
        public CardId(int id) : base(IdType.Card, id) {}
        public CardId() {}
    }
}