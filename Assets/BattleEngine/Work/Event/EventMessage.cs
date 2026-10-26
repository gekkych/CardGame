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
                    $"{dae.Metadata.Attacker.Name} {dae.Attacker} attacks {dae.Metadata.Target.Name} {dae.Target} with {dae.Amount} damage; ({dae.Metadata.OldValue}->{dae.Metadata.NewValue}); source: {dae.Source}",
               
                HealEvent hee =>
                    $"{hee.Metadata.Target.Name} {hee.Target} heals by {hee.Amount} ({hee.Metadata.OldValue}->{hee.Metadata.NewValue})",
                
                DeathEvent dee =>
                    $"{dee.Metadata.Target.Name} {dee.Target} died",
                
                BonusChangeEvent bce =>
                    $"{bce.Name} {bce.Id} bonus {bce.Bonus.ToString()} changes for {bce.Delta}",
                
                ReplaceCompEvent rce =>
                    $"#{rce.Target} {rce.TargetName}'s component {rce.ToReplace} changed",
                
                AddCompEvent ace =>
                    $"#{ace.Target} {ace.TargetName}'s component {ace.ComponentName} added",

                
                RemoveCompEvent rce =>
                    $"#{rce.Target} {rce.TargetName}'s component {rce.ComponentName} removed",
                
                EndTurnEvent ete =>
                    $"New Turn #{ete.NewTurnNumber}",
                
                PlaceUnitEvent pue =>
                    $"Unit {pue.Unit} placed at {pue.Position}",
                
                _ =>
                    "Log Error"
            };
        }
    }
}