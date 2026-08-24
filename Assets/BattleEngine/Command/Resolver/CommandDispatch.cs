using System.Collections.Generic;
using BattleEngine.Work.Step;
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
                _ => new List<BaseStep>()
            };
        }
    }
}