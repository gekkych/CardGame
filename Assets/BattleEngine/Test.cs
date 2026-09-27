using System.Collections.Generic;
using BattleEngine.Cards;
using BattleEngine.Command;
using BattleEngine.Id;
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
            BattleState initialState =  new BattleState(0, 6, 8);
            var lonely = UnitLibrary.Healer(initialState.IdProvider);
            var friend1 = UnitLibrary.Healer(initialState.IdProvider);
            var friend2 = UnitLibrary.Healer(initialState.IdProvider);
            var warrior = UnitLibrary.Warrior(initialState.IdProvider);
            var slime = UnitLibrary.Slime(initialState.IdProvider);

            slime.AddComp(new ThornComp(2));
            
            lonely.State.CurrHp = 1;
            friend1.State.CurrHp = 1;
            friend2.State.CurrHp = 1;
            
            initialState.Board.Add(new Position(1, 1), lonely);
            initialState.Board.Add(new Position(4, 4), friend1);
            initialState.Board.Add(new Position(4, 5), friend2);
            initialState.Board.Add(new Position(2, 2), warrior);
            initialState.Board.Add(new Position(2, 3), slime);
            
            BattleEngine engine = new BattleEngine(initialState);
            engine.TestInit(initialState);

            Turn(engine, new AttackContext(
                new Position(2,2), 
                new Position(2,3), 
                AttackLibrary.DoubleSlash())
            ,true);
            Turn(engine, new AttackContext(
                new Position(2, 2), 
                new Position(2, 3), 
                AttackLibrary.DoubleSlash())
            ,true);
        }

        [Test]
        public void VampTest()
        {
            BattleState initialState =  new BattleState(0, 1, 2);
            
            var warrior = UnitLibrary.Warrior(initialState.IdProvider);
            var slime = UnitLibrary.Slime(initialState.IdProvider);
            initialState.Board.Add(new Position(0, 0), warrior);
            initialState.Board.Add(new Position(0, 1), slime);
            warrior.AddComp(new VampirismComp(3));
            
            BattleEngine engine = new BattleEngine(initialState);
            engine.TestInit(initialState);
            
            Turn(engine, new AttackContext(
                new Position(0,1), 
                new Position(0,0), 
                AttackLibrary.DoubleSlash()));
            
            Turn(engine, new AttackContext(
                    new Position(0,0), 
                    new Position(0,1), 
                    AttackLibrary.Slash()));
        }

        private void Turn(BattleEngine engine, CommandContext ctx, bool showRaw = false)
        {
            var events = engine.Turn(ctx);

            foreach (var e in events)
            {
                if (showRaw) TestContext.WriteLine(e);
                if (!showRaw) TestContext.WriteLine(EventMessage.ToString(e));
            }
        }
    }
}