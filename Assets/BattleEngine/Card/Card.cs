using System;

namespace BattleEngine
{
    public abstract class Card 
    {
        public int ID { get; set; }
        public float MaxHP { get; protected set; }
        public float  HP  { get; set; } //SOUL SHIELD
        public int BaseDamage { get; set; }
        public Effect Effect { get; set; }
        
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