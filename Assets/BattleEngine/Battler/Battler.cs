using System;

namespace BattleEngine
{
    public abstract class Battler 
    {
        public int ID { get; private set; }
        public string Name { get; protected set; }
        public float MaxHP { get; protected set; }
        public float  HP  { get; set; } //SOUL SHIELD
        
        public void Damage(float damage)
        {
            if (damage < 0) return;
            HP -= damage;
            HP = Math.Max(0, HP);
        }

        public void Heal(float heal)
        {
            if (heal < 0) return;
            HP += heal;
            HP = Math.Max(MaxHP, HP);
        }
    }
}