using BattleEngine.Cards;
using BattleEngine.Command;
using BattleEngine.Unit;
using BattleEngine.Unit.Attack;
using BattleEngine.Unit.Component;
using BattleEngine.Work.Event;
using NUnit.Framework;

namespace BattleEngine
{
    [TestFixture]
    public class Test
    {
        [Test]
        public void BattleTest()
        {
            BattleState initialState =  new BattleState(5, 8);
            var warrior = UnitLibrary.Warrior();
            var slime = UnitLibrary.Slime();
            slime.AddComp(new ThornComp(3));
            initialState.Board.Add(new Position(2, 3), warrior);
            initialState.Board.Add(new Position(2, 5), slime);

            
            BattleEngine engine = new BattleEngine(initialState);
            engine.TestInit(initialState);

            var events = engine.Turn(new AttackContext(
                new Position(2, 3),
                new Position(2, 5),
                AttackLibrary.FireSpear()));

            foreach (var e in events)
            {
                TestContext.WriteLine(EventMessage.ToString(e));
            }
        }
    }
}