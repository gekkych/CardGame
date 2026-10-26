using System;
using System.Collections.Generic;
using BattleEngine.Id;

namespace BattleEngine.Work.Step.Target
{
    public struct TargetResult
    {
        public IReadOnlyList<IdUnion> Ids;
        public readonly bool ToGroup;

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
        
        public static TargetResult None => new(Array.Empty<IdUnion>());
        public static TargetResult One(IdUnion id) => new(new[] { id });
        public static TargetResult Many(params IdUnion[] ids) => new(ids);
        public static TargetResult Many(List<IdUnion> ids) => new(ids);
        public static TargetResult Group(params IdUnion[] ids) => new(ids, true);
        public static TargetResult Group(List<IdUnion> ids) => new(ids, true);
    }
}