namespace BattleEngine.Work.Event.Applier
{
    public static class EventApplier
    {
        public static void Apply(BaseEvent e, BattleState state)
        {
            switch (e)
            {
                case DamageEvent dae:
                    state.GetUnit(dae.Target).State.CurrHp -= dae.Amount;
                    break;
                
                case DeathEvent dee:
                    state.Board.Remove(dee.To);
                    break;
                
                case BonusChangeEvent bce:
                    state.GetUnit(bce.Id).State.
                        ChangeBonus(bce.Bonus, bce.Delta);
                    break;
            }
        }
    }
}