using GMTB.Entities.AI;
using GMTB.Interfaces;
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
    }
}
