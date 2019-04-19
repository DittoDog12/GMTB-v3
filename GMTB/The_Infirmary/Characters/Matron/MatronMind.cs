using GMTB.CollisionSystem;
using GMTB.Entities.AI;
using GMTB.Interfaces;
using GMTB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Infirmary.Characters.Matron
{
    public class MatronMind : AIMind
    {
        public MatronMind(IBasicAI _self) : base(_self)
        {
            mStates.Add("idle", new Idle(this));
            mStates.Add("persue", new Persue(this));

            mCurrentState = mStates["idle"];
        }
        public override void OnTrigger(ICollidable _obj)
        {
            // If collision with player, trigger game over
            IPlayer asInterface = _obj as IPlayer;
            if (asInterface != null)
                Global.GameState = Global.availGameStates.GameOver;
        }
    }
}
