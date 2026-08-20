using System.Collections.Generic;

namespace BattleEngine.Work.Step.Target
{
    //end point target
    public class IdTarget : ITarget
    {
        private int _id;
        public int Id => _id;

        public IdTarget(int id)
        {
            _id = id;
        }
        
        public List<int?> ResolveTarget(BattleState state, int lastId)
        {
            List<int?> ids = new();
            ids.Add(state.GetUnit(_id)?.UnitId);
            return ids;
        }
    }
}