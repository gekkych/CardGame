using System.Linq;
using BattleEngine.Cards;
using BattleEngine.Command;
using BattleEngine.Enums;
using BattleEngine.Unit;
using BattleEngine.Unit.Attack;
using BattleEngine.Unit.Component;
using BattleEngine.Work.Event;
using NUnit.Framework;

namespace BattleEngine.Tests
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

        [Test]
public void ExplosionTest()
{
    var initialState = new BattleState(0, 40, 40);

    var warrior = UnitLibrary.Warrior(initialState.IdProvider);
    var slime1 = UnitLibrary.Slime(initialState.IdProvider);
    var slime2 = UnitLibrary.Slime(initialState.IdProvider);
    var slime3 = UnitLibrary.Slime(initialState.IdProvider);

    var warriorHp = warrior.State.CurrHp;
    var slime3Hp = slime3.State.CurrHp;

    slime1.AddComp(new ThornComp(2));
    slime2.AddComp(new ThornComp(2));
    slime3.AddComp(new ThornComp(2));

    initialState.Board.Add(new Position(0, 0), warrior);
    initialState.Board.Add(new Position(12, 11), slime1);
    initialState.Board.Add(new Position(12, 13), slime2);
    initialState.Board.Add(new Position(38, 38), slime3);

    var engine = new BattleEngine(initialState);
    engine.TestInit(initialState);

    var ctx = new AttackContext(
        Position.Pos(0, 0),
        Position.Pos(12, 12),
        AttackLibrary.Explosion())
    {
        AttackerShouldExists = true,
        TargetShouldExists = false
    };

    var events = engine.Turn(ctx);

    foreach (var e in events)
    {
        TestContext.WriteLine(EventMessage.ToString(e));
    }

    var damageEvents = events
        .OfType<DamageEvent>()
        .ToArray();
    
    Assert.That(
        damageEvents.Select(e => e.Source).ToArray(),
        Is.EqualTo(new[]
        {
            DamageSource.Explosion,
            DamageSource.Explosion,
            DamageSource.Thorn,
            DamageSource.Thorn
        }));
    
    Assert.That(
        damageEvents.Take(2).Select(e => e.Target).ToArray(),
        Is.EquivalentTo(new[]
        {
            slime1.UnitId.Raw,
            slime2.UnitId.Raw
        }));
    
    Assert.That(
        damageEvents.Skip(2).Select(e => e.Target).ToArray(),
        Is.EqualTo(new[]
        {
            warrior.UnitId.Raw,
            warrior.UnitId.Raw
        }));

    Assert.That(warrior.State.CurrHp, Is.EqualTo(warriorHp - 10));
    Assert.That(slime3.State.CurrHp, Is.EqualTo(slime3Hp));
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