using BattleEngine.Work.Event.ComponentEvent;

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
               
                HealEvent hee =>
                    $"{hee.ToName} {hee.To} heals by {hee.Amount} ({hee.OldValue}->{hee.NewValue})",
                
                DeathEvent dee =>
                    $"{dee.ToName} {dee.To} died",
                
                BonusChangeEvent bce =>
                    $"{bce.Name} {bce.Id} bonus {bce.Bonus.ToString()} changes for {bce.Delta}",
                
                ReplaceCompEvent rce =>
                    $"#{rce.Target} {rce.TargetName}'s component {rce.ToReplace} changed",
                
                RemoveCompEvent rce =>
                    $"#{rce.Target} {rce.TargetName}'s component {rce.ComponentName} removed",
                
                EndTurnEvent ete =>
                    $"New Turn #{ete.NewTurnNumber}",
                
                _ =>
                    "Log Error"
            };
        }
    }
}