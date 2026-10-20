using BattleEngine.Cards;
using BattleEngine.Enums;
using BattleEngine.Id;
using BattleEngine.Id.RuntimeId;
using BattleEngine.State;

namespace BattleEngine.Work.Event.Metadata
{
    public record EntityMetadata(
        IdUnion Id,
        string Name,
        int Health,
        int MaxHealth,
        Position? Position,
        BoardSide? Side)
    {
        public static EntityMetadata FromState(IdUnion id, BattleState state)
        {
            if (id == null) return null;

            if (id.To<UnitId>(out var unitId))
            {
                var unit = state.GetUnit(unitId);
                if (unit == null) return null;
                return new EntityMetadata(id, unit.Stats.Type.ToString(),
                    unit.State.CurrHp, unit.Stats.MaxHealth, state.Board.GetPosition(unit), null);
            }

            if (id.To<BattlerId>(out var battlerId))
            {
                var battler = state.GetBattler(battlerId);
                if (battler == null) return null;
                var data = battler.BattlerData;
                return new EntityMetadata(id, data.Type.ToString(), data.Shield, data.MaxShield,
                    null, state.BattlersStateManager.GetSide(battlerId));
            }

            return null;
        }
    }
}