namespace BattleEngine
{
    public class SimpleCard : Card
    {
        public SimpleCard(BattleContext context)
        {
            Effect = new EffectBuilder()
                .Damage(context.Board.Lanes[0].OpponentCard, 20.0f)
                .Build();
        }
    }
}