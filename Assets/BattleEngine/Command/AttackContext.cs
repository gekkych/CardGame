using BattleEngine.Unit.Attack;

namespace BattleEngine.Command
{
    public sealed record AttackContext(
        int From, 
        int To, 
        Attack Attack) 
        : CommandContext;
}