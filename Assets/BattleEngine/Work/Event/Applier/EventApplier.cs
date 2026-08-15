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
                    state.GetUnit(damageEvent.Target).State.CurrHp -= damageEvent.Amount;
                    break;
                
                case HealEvent healEvent:
                    state.GetUnit(healEvent.To).State.CurrHp += healEvent.Amount;
                    break;
                
                case DeathEvent deathEvent:
                    state.Board.Remove(deathEvent.To);
                    break;
                
                case BonusChangeEvent bonusChangeEvent:
                    state.GetUnit(bonusChangeEvent.Id).State.
                        ChangeBonus(bonusChangeEvent.Bonus, bonusChangeEvent.Delta);
                    break;
                
                case RemoveCompEvent removeCompEvent:
                    state.GetUnit(removeCompEvent.Target).RemoveComp(removeCompEvent.ComponentName);
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