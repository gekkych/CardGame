using BattleEngine.Id.RuntimeId;
using BattleEngine.Work.Event.ComponentEvent;

namespace BattleEngine.Work.Event.Applier
{
    public static class EventApplier
    {
        public static void Apply(BaseEvent e, BattleState state)
        {
            switch (e)
            {
                case DamageEvent damageEvent:
                    if (damageEvent.Target.To<UnitId>(out var de_unitId))
                    {
                        var unit = state.GetUnit(de_unitId);
                        unit!.State.CurrHp -= damageEvent.Amount;
                    }
                    if (damageEvent.Target.To<BattlerId>(out var de_battlerId))
                    {
                        var battler = state.GetBattler(de_battlerId);
                        battler.BattlerData.Shield -= damageEvent.Amount;
                    }

                    break;
                
                case HealEvent healEvent:
                    if (healEvent.Target.To<UnitId>(out var he_unitId))
                    {
                        var unit = state.GetUnit(he_unitId);
                        unit!.State.CurrHp -= healEvent.Amount;
                    }
                    if (healEvent.Target.To<BattlerId>(out var he_battlerId))
                    {
                        var battler = state.GetBattler(he_battlerId);
                        battler.BattlerData.Shield -= healEvent.Amount;
                    }
                    break;
                
                case DeathEvent deathEvent:
                    if (deathEvent.Target.To<UnitId>(out var dee_unitId))
                    {
                        state.Board.Remove(dee_unitId);
                    }
                    if (deathEvent.Target.To<BattlerId>(out var dee_battlerId))
                    {
                        state.BattlerDied(dee_battlerId);
                    }
                    break;
                
                case BonusChangeEvent bonusChangeEvent:
                    state.GetUnit(bonusChangeEvent.Id).State.
                        ChangeBonus(bonusChangeEvent.Bonus, bonusChangeEvent.Delta);
                    break;
                
                case RemoveCompEvent removeCompEvent:
                    state.GetUnit(removeCompEvent.Target).RemoveComp(removeCompEvent.ComponentName);
                    break;
                
                case AddCompEvent addCompEvent:
                    state.GetUnit(addCompEvent.Target).AddComp(addCompEvent.Added);
                    break;
                
                case ReplaceCompEvent replaceCompEvent:
                    state.GetUnit(replaceCompEvent.Target).RemoveComp(replaceCompEvent.OldComponent.Name);
                    state.GetUnit(replaceCompEvent.Target).AddComp(replaceCompEvent.NewComponent);
                    break;
                
                case EndTurnEvent:
                    state.Turn++;
                    break;
                
                default:
                    throw new System.NotImplementedException();
            }
        }
    }
}