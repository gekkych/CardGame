using BattleEngine.Enums;

namespace BattleEngine.Id.RuntimeId
{
    public abstract class UnionIdWrapper
    {
        public IdUnion Raw { get; set; }

        public UnionIdWrapper() => Raw = null;
        protected UnionIdWrapper(IdType type, int id)
        {
            Raw = new IdUnion(type, id);
        }
        
        public int Id => Raw.Id;
        
        public override string ToString() => Id.ToString();
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj is not UnionIdWrapper other) return false;
            if (other.Raw.IdType != Raw.IdType) return false;
            return Id.Equals(other.Id);
        }
        public override int GetHashCode() => Id.GetHashCode();
    }
}