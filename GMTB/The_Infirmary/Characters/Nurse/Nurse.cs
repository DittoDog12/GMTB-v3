using GMTB.Entities.AI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Infirmary.Characters.Nurse
{
    public class Nurse : BasicAI
    {
        public Nurse()
        {
            mMind = new NurseMind(this);
        }
    }
}
