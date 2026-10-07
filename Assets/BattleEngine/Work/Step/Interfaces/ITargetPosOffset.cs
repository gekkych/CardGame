using BattleEngine.Cards;
using BattleEngine.Work.Step.Target;

namespace BattleEngine.Work.Step.Interfaces
{
    public interface ITargetPosOffset
    {
        public ITarget Offset(Position offset);
    }
}