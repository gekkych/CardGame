using System.Collections.Generic;
using BattleEngine.State;
using BattleEngine.Work.Step.Interfaces;

namespace BattleEngine.Command.Resolver
{
    public static class CommandDispatch
    {
        public static List<BaseStep> Resolve(BattleState state, CommandContext ctx)
        {
            return ctx switch
            {
                SkipTurnContext => new List<BaseStep>(),
                AttackContext attackContext => new AttackCommandResolver().Resolve(state, attackContext),
                PlayCardContext playCardContext => new PlayCardCommandResolver().Resolve(state, playCardContext),
                _ => new List<BaseStep>()
            };
        }
    }
}