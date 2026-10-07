using BattleEngine.Cards;
using BattleEngine.Unit.Attack;

namespace BattleEngine.Command
{
    public sealed record AttackContext(
        Position FromPos,
        Position ToPos,
        Attack Attack)
        : CommandContext
    {
        public bool AttackerShouldExists { get; init; } = true;
        public bool TargetShouldExists   { get; init; } = true;
    }
}