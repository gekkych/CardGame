using System;
using BattleEngine.Battler;
using BattleEngine.Id.RuntimeId;

namespace BattleEngine.State
{
    //mutates State
    //mutation only via EventApplier 
    public class BattlersStateManager
    {
        private BattleState _lookUpState;
        
        public BattlersStateManager(BattleState lookUpState)
        {
            _lookUpState = lookUpState;
        }

        public BaseBattler GetBattler(BattlerId battlerId)
        {
            throw new NotImplementedException();
        }
    }
}