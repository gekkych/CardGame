using System.Collections.Generic;
using BattleEngine.State;
using BattleEngine.Work.Step.Interfaces;

namespace BattleEngine.Command.Resolver
{
    public interface ICommandResolver<TCtx> where TCtx : CommandContext
    {
        public List<BaseStep> Resolve(BattleState state, TCtx ctx);
    }
}