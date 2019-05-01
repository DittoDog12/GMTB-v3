using GMTB.Entities.AI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Infirmary.Characters.Doctor
{
    /// <summary>
    /// Class for the Doctor
    /// </summary>
    public class Doctor : BasicAI
    {
        /// <summary>
        /// Main Constructor
        /// Creates Doctors Mind
        /// </summary>
        public Doctor()
        {
            mMind = new DoctorMind(this);
        }
    }
}
