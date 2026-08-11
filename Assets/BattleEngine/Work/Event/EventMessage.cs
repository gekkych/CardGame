using System.Data;

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
                
                _ =>
                    "Log Error"
            };
        }
    }
}