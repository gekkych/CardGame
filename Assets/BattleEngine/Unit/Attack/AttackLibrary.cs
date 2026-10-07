using System.Collections.Generic;
using BattleEngine.Cards;
using BattleEngine.Enums;
using BattleEngine.Id.DefId;
using BattleEngine.Id.RuntimeId;
using BattleEngine.Unit.Component;
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
                UnitId.Placeholder.Raw,
                new PosTarget(new Position(0, 0)),
                6,
                DamageSource.Attack
            ));
            
            steps.Add(new AddCompStep(
                new SameAsLast(),
                new BurnComp(3, 2)
                ));

            var a = new Attack
            {
                ID = AttackDef.FireSpear,
                Steps = steps
            };
            return a;
        }
        
        public static Attack Slash()
        {
            var steps = new List<BaseStep>();

            steps.Add(new DamageStep(
                UnitId.Placeholder.Raw,
                new PosTarget(new Position(0, 0)),
                5,
                DamageSource.Attack
            ));
            
            var a = new Attack
            {
                ID = AttackDef.Slash,
                Steps = steps
            };
            return a;
        }
        
        public static Attack DoubleSlash()
        {
            var steps = new List<BaseStep>();

            steps.Add(new DamageStep(
                UnitId.Placeholder.Raw,
                new PosTarget(new Position(0, 0)),
                5,
                DamageSource.Attack
            ));
            
            steps.Add(new DamageStep(
                UnitId.Placeholder.Raw,
                new PosTarget(new Position(0, 0)),
                5,
                DamageSource.Attack
            ));
            
            var a = new Attack
            {
                ID = AttackDef.DoubleSlash,
                Steps = steps
            };
            return a;
        }

        public static Attack Explosion()
        {
            var steps = new List<BaseStep>();
            
            steps.Add(new DamageStep(
                UnitId.Placeholder.Raw,
                new PatternTarget(new Position(0, 0), Pattern.Patterns.Radius(3)),
                5,
                DamageSource.Explosion));

            var a = new Attack
            {
                ID = AttackDef.Explosion,
                Steps = steps
            };

            return a;
        }
    }
}