using System.Collections.Generic;
using BattleEngine.Work.Step;
using BattleEngine.Work.Step.Interfaces;

namespace BattleEngine.Command.Resolver
{
    public interface ICommandResolver<TCtx> where TCtx : CommandContext
    {
        public List<BaseStep> Resolve(BattleState state, TCtx ctx);
    }
}