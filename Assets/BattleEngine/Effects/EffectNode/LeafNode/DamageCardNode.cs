namespace BattleEngine
{
    public class DamageCardNode : IEffectNode
    {
        public Card Target { get; }
        public float Damage { get; }

        public DamageCardNode(Card target, float damage)
        {
            Target = target;
            Damage = damage;
        }
        public void Execute(BattleContext context)
        {
            Target.Damage(Damage);
        }
    }
}