namespace BattleEngine.Work.Event
{
    public static class EventMessage
    {
        public static string ToString(BaseEvent e)
        {
            return e switch
            {
                DamageEvent dae =>
                    $"{dae.AttackerName} {dae.Attacker} attacks {dae.TargetName} {dae.Target} with {dae.Amount} damage; ({dae.OldValue}->{dae.NewValue}); source: {dae.Source}",
               
                DeathEvent dee =>
                    $"{dee.ToName} {dee.To} died",
                
                BonusChangeEvent bce =>
                    $"{bce.Name} {bce.Id} bonus {bce.Bonus.ToString()} changes for {bce.Delta}",
                
                _ =>
                    "Log Error"
            };
        }
    }
}