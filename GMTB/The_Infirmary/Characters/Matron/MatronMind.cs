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
    /// <summary>
    /// Mind for the Matron AI
    /// </summary>
    public class MatronMind : AIMind
    {
        /// <summary>
        /// Main Constructor
        /// </summary>
        /// <param name="_self">Reference to the host</param>
        public MatronMind(IBasicAI _self) : base(_self)
        {
            mStates.Add("idle", new Idle(this));
            mStates.Add("persue", new Persue(this));

            mCurrentState = mStates["idle"];
        }
        /// <summary>
        /// On Collision trigger game over
        /// </summary>
        /// <param name="_obj"></param>
        public override void Collision(ICollidable _obj)
        {
            // If collision with player, trigger game over
            IPlayer asInterface = _obj as IPlayer;
            if (asInterface != null)
                Global.GameState = Global.availGameStates.GameOver;
        }
    }
}