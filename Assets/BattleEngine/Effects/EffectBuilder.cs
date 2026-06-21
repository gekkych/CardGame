namespace BattleEngine
{
    /*
     * Target to make syntax like that
     *  effect_builder
     *   .ForEachStart(List)
     *        .Damage(util.iter_impl, 20)
     *        .IfStart(new StatCondition(
     *          Stats.HP,
     *          enemy.HP,
     *          enemy.Max_HP * 0.2,
     *          util.Condition.LEQ
     *        ))
     *          .ChangeStat(util.iter_impl, Stats.HP, 0)
     *        .IfEnd()
     *   .ForEachEnd()
     *   .Damage(enemy, 10)
     *   .ChangeStat(player, Stats.HP, 3, 0.2) // target, stat, value, chance 
     */
    public class EffectBuilder
    {
        Effect _effect = new Effect();
        public EffectBuilder Damage(Card target, float damage)
        {
            _effect._nodes.Add(new DamageCardNode(target, damage));
            return this;
        }

        public Effect Build()
        {
            return _effect;
        }
    }
}