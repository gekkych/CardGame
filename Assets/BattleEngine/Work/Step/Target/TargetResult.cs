using System.Collections.Generic;
using BattleEngine.Id;

namespace BattleEngine.Work.Step.Target
{
    public struct TargetResult
    {
        public IReadOnlyList<IdUnion> Ids;
        public bool ToGroup;

        public TargetResult(IReadOnlyList<IdUnion> ids, bool toGroup)
        {
            Ids = ids;
            ToGroup = toGroup;
        }

        public TargetResult(IReadOnlyList<IdUnion> ids)
        {
            Ids = ids;
            ToGroup = false;
        }
    }
}