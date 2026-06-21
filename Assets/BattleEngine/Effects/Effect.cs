using System.Collections.Generic;

namespace BattleEngine
{
    public class Effect //DTO
    {
        public List<IEffectNode> _nodes { get; } = new();
    }
}