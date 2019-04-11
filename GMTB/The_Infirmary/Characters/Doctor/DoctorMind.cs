using GMTB.Entities.AI;
using GMTB.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Infirmary.Characters.Doctor
{
    public class DoctorMind : AIMind
    {
        public DoctorMind(IBasicAI _self) : base(_self)
        {
            mStates.Add("idle", new Idle(this));
            mStates.Add("walk", new Walk(this));

            mCurrentState = mStates["idle"];
        }
    }
}
