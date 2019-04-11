using GMTB.Entities.AI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Infirmary.Characters.Matron
{
    class Matron : BasicAI
    {
        public Matron()
        {
            mMind = new MatronMind(this);
        }
    }
}
