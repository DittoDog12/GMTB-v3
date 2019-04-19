using GMTB.CollisionSystem;
using GMTB.Entities.AI;
using GMTB.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Infirmary.Characters.Nurse
{
    class NurseMind : AIMind
    {
        public NurseMind(IBasicAI _self) : base(_self)
        {
            mStates.Add("idle", new Idle(this));
            mStates.Add("persue", new Persue(this));

            mCurrentState = mStates["idle"];
        }

        public override void OnTrigger(ICollidable _obj)
        {
            // If collision with player, call the level manager and restart the current level.
            IPlayer asInterface = _obj as IPlayer;
            if (asInterface != null)
                mSelf.ServiceLocator.GetService<ILevel_Manager>().RestartLevel();
        }
    }
}
