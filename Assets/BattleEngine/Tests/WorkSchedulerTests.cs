using BattleEngine.Enums;
using BattleEngine.Id;
using BattleEngine.Work;
using BattleEngine.Work.Event;
using BattleEngine.Work.Step.Target;
using BattleEngine.Work.Step.UnitStateStep;
using NUnit.Framework;

namespace BattleEngine.Tests
{
    [TestFixture]
    public class WorkSchedulerTests
    {
        private static IdUnion UnitId(int id)
        {
            return new IdUnion(IdType.Unit, id);
        }

        [Test]
        public void PriorityWork_ShouldBePoppedBeforeStandardWork()
        {
            var scheduler = new WorkScheduler();

            var standard1 = new EventWork(
                new DeathEvent(UnitId(1), "standard1"),
                Depth: 0,
                NextReact: 0
            );
            
            var standard2 = new EventWork(
                new DeathEvent(UnitId(1), "standard2"),
                Depth: 0,
                NextReact: 0
            );

            var priority = new EventWork(
                new DeathEvent(UnitId(2), "priority"),
                Depth: 0,
                NextReact: 0
            )
            {
                Priority = 1
            };

            scheduler.Push(standard2); 
            scheduler.Push(priority);
            scheduler.Push(standard1);

            Assert.That(scheduler.TryPop(out var first), Is.True);
            Assert.That(first, Is.EqualTo(priority));

            Assert.That(scheduler.TryPop(out var second), Is.True);
            Assert.That(second, Is.EqualTo(standard1));
            
            Assert.That(scheduler.TryPop(out var third), Is.True);
            Assert.That(third, Is.EqualTo(standard2));
        }

        [Test]
        public void SmallerPriority_ShouldBePoppedFirst()
        {
            var scheduler = new WorkScheduler();

            var priority5 = new EventWork(
                new DeathEvent(UnitId(1), "p5"),
                0,
                0
            )
            {
                Priority = 5
            };

            var priority1 = new EventWork(
                new DeathEvent(UnitId(2), "p1"),
                0,
                0
            )
            {
                Priority = 1
            };

            scheduler.Push(priority1);
            scheduler.Push(priority5);

            scheduler.TryPop(out var first);
            scheduler.TryPop(out var second);

            Assert.That(first, Is.EqualTo(priority1));
            Assert.That(second, Is.EqualTo(priority5));
        }

        [Test]
        public void StandardWork_ShouldBehaveLikeStack()
        {
            var scheduler = new WorkScheduler();

            var first = new DeathStep(
                new IdTarget(UnitId(1))
            );

            var second = new DeathStep(
                new IdTarget(UnitId(2))
            );

            var firstWork = new StepWork(first, 0);
            var secondWork = new StepWork(second, 0);

            scheduler.Push(firstWork);
            scheduler.Push(secondWork);

            scheduler.TryPop(out var popped);

            Assert.That(popped, Is.EqualTo(secondWork));
        }
    }
}