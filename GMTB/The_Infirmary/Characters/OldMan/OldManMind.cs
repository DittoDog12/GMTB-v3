using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMTB.Entities.AI;
using GMTB.Interfaces;
namespace The_Infirmary.Characters.OldMan
{
    /// <summary>
    /// Old Man Burt Mind
    /// </summary>
    public class OldManMind : AIMind
    {
        /// <summary>
        /// Main Constructor
        /// </summary>
        /// <param name="_self">Reference to himself</param>
        public OldManMind(IBasicAI _self) :base(_self)
        {
            mStates.Add("idle", new Idle(this));
            mStates.Add("talk", new Talk(this));
            mStates.Add("yeet", new Yeet(this));
            mStates.Add("run", new Run(this));

            mCurrentState = mStates["idle"];
        }
    }
}
