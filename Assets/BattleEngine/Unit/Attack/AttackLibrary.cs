using System.Collections.Generic;
using BattleEngine.Cards;
using BattleEngine.Enums;
using BattleEngine.Unit.Component;
using BattleEngine.Work.Step;
using BattleEngine.Work.Step.CompStep;
using BattleEngine.Work.Step.Interfaces;
using BattleEngine.Work.Step.Target;
using BattleEngine.Work.Step.UnitStateStep;

namespace BattleEngine.Unit.Attack
{
    public static class AttackLibrary
    {
        public static Attack FireSpear()
        {
            var steps = new List<BaseStep>();

            steps.Add(new DamageStep(
                -1,
                new PosTarget(new Position(0, 0)),
                6,
                DamageSource.Attack
            ));
            
            steps.Add(new AddCompStep(
                new SameAsLast(),
                new BurnComp(3, 2)
                ));

            var a = new Attack();
            a.ID = 0;
            a.Steps = steps;
            return a;
        }
        
        public static Attack Slash()
        {
            var steps = new List<BaseStep>();

            steps.Add(new DamageStep(
                -1,
                new PosTarget(new Position(0, 0)),
                5,
                DamageSource.Attack
            ));
            
            var a = new Attack();
            a.ID = 1;
            a.Steps = steps;
            return a;
        }
        
        public static Attack DoubleSlash()
        {
            var steps = new List<BaseStep>();

            steps.Add(new DamageStep(
                -1,
                new PosTarget(new Position(0, 0)),
                5,
                DamageSource.Attack
            ));
            
            steps.Add(new DamageStep(
                -1,
                new PosTarget(new Position(0, 0)),
                5,
                DamageSource.Attack
            ));
            
            var a = new Attack();
            a.ID = 1;
            a.Steps = steps;
            return a;
        }
    }
}