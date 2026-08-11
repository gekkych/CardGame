using System.Collections.Generic;
using BattleEngine.Work.Event;

namespace BattleEngine.Work.Step.Resolver
{
    public interface IStepResolver<TStep> where TStep : BaseStep
    {
        List<BaseEvent> Resolve(
            TStep step,
            BattleState state
            );
    }
}