namespace BattleEngine
{
    public class EffectAplier
    {
        public BattleContext ctx { get; }
        
        public EffectAplier(BattleContext ctx)
        {
            this.ctx = ctx;
        }

        public void ApplyEffect(Effect effect)
        {
            foreach (IEffectNode node in effect._nodes)
            {
                node.Execute(ctx);
            }
        }
    }
}