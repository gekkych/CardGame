using BattleEngine.Cards.Card;
using BattleEngine.Id.RuntimeId;
using BattleEngine.State;

namespace BattleEngine.Command
{
    public record PlayCardContext(
        BattlerId ID,
        BaseUnitCard Card,
        Position Position) : CommandContext;
}