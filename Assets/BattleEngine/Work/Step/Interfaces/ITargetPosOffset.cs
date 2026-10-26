using BattleEngine.Cards;
using BattleEngine.State;
using BattleEngine.Work.Step.Target;

namespace BattleEngine.Work.Step.Interfaces
{
    public interface ITargetPosOffset
    {
        public ITarget Offset(Position offset);
    }
}