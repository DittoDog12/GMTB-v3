using GMTB.Entities.AI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Infirmary.Characters.Doctor
{
    public class Doctor : BasicAI
    {
        public Doctor()
        {
            mMind = new DoctorMind(this);
        }
    }
}
