using System;
using BattleEngine.Enums;
using BattleEngine.Id.RuntimeId;

namespace BattleEngine.Id
{
    public class IdUnion
    {
        private readonly IdType _idType;
        private readonly int _id;

        public IdUnion(IdType idType, int id)
        {
            _idType = idType;
            _id = id;
        }
        
        public IdType IdType => _idType;
        public int Id => _id;

        public bool To<T>(out T wrapper) where T : UnionIdWrapper, new()
        {
            wrapper = null;
            if (
                (typeof(T) == typeof(UnitId)    && _idType == IdType.Unit   )   ||
                (typeof(T) == typeof(BattlerId) && _idType == IdType.Battler)   ||
                (typeof(T) == typeof(CardId)    && _idType == IdType.Card   )   ||
                (typeof(T) == typeof(AttackId)  && _idType == IdType.Attack )
                ) {
                wrapper = new T();
                wrapper.Raw = this;
                return true;
            }
            return false;
        }

        public override string ToString() => _id.ToString();
        
        public static bool operator ==(IdUnion left, IdUnion right)
        {
            if (left is null)
                return right is null;

            if (right is null)
                return false;

            return left._idType == right._idType &&
                   left._id == right._id;
        }

        public static bool operator !=(IdUnion left, IdUnion right)
        {
            return !(left == right);
        }

        public override bool Equals(object obj)
        {
            return obj is IdUnion other && this == other;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_idType, _id);
        }
    }
}