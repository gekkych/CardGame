namespace BattleEngine
{
    public class BattleEngine 
    {
        public Board Board { get; private set; }
        public BattleContext ctx  { get; private set; }
        public EffectAplier Aplier { get; private set; }
        
        public BattleEngine(Board board)
        {
            Board = board;
            ctx = new BattleContext();
            Aplier = new EffectAplier(ctx);
        }

        public void NextTurn()
        {
            switch (ctx.Turn)
            {
                
            }
        }
    }
}