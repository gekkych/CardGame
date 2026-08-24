using System.Collections.Generic;
using BattleEngine.Work.Step.Interfaces;

namespace BattleEngine.Work.Step.Resolver
{
    public interface IStepResolver<in TStep> where TStep : BaseStep
    {
        public List<IExecutable> Resolve(TStep step, BattleState state);
    }
}