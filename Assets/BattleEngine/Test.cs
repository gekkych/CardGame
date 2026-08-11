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
            BattleState initialState =  new BattleState();
            initialState.Board.Good = UnitLibrary.Warrior();
            initialState.Board.Bad = UnitLibrary.Slime();
            
            BattleEngine engine = new BattleEngine();
            engine.TestInit(initialState);

            var events = engine.Battle(new AttackContext(
                initialState.Board.Good.UnitId,
                initialState.Board.Bad.UnitId,
                AttackLibrary.DoubleSlash));

            foreach (var e in events)
            {
                TestContext.WriteLine(EventMessage.ToString(e));
            }
        }

        [Test]
        public void ThornTest()
        {
            BattleState initialState = new BattleState();
            initialState.Board.Good = UnitLibrary.Warrior();
            initialState.Board.Bad = UnitLibrary.Slime();
            initialState.Board.Bad.Comps.Add(Comps.Thorn);

            BattleEngine engine = new BattleEngine();
            engine.TestInit(initialState);

            var events = engine.Battle(new AttackContext(
                initialState.Board.Good.UnitId,
                initialState.Board.Bad.UnitId,
                AttackLibrary.DoubleSlash));

            foreach (var e in events)
            {
                TestContext.WriteLine(EventMessage.ToString(e));
            }

        }
        
        [Test]
        public void ThornAttackerDeathTest()
        {
            BattleState initialState = new BattleState();
            initialState.Board.Good = UnitLibrary.Warrior();
            initialState.Board.Bad = UnitLibrary.Slime();
            initialState.Board.Bad.Comps.Add(Comps.Thorn);
            initialState.Board.Good.State.CurrHp = 2;

            BattleEngine engine = new BattleEngine();
            engine.TestInit(initialState);

            var events = engine.Battle(new AttackContext(
                initialState.Board.Good.UnitId,
                initialState.Board.Bad.UnitId,
                AttackLibrary.DoubleSlash));

            foreach (var e in events)
            {
                TestContext.WriteLine(EventMessage.ToString(e));
            }

        }
    }
}