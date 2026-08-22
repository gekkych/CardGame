namespace BattleEngine.Command.Exception
{
    public class InvalidAttackException : System.Exception
    {
        public InvalidAttackException(AttackContext ctx) : base(message: ctx.ToString())
        {}
    }
}