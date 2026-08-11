using System.Collections.Generic;
using BattleEngine.Work.Event;
using BattleEngine.Work.Step;

namespace BattleEngine.Reaction
{
    public abstract class BaseReaction
    {
        public int Priority { get; set; }

        public abstract List<BaseStep> React(BaseEvent e, BattleState state);

        //hooks
        public abstract void NewRootStep();
        public abstract void NewTurn();
    }
}