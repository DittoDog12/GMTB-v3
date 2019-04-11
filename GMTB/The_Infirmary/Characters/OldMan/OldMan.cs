using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMTB.Entities.AI;

namespace The_Infirmary.Characters.OldMan
{
    class OldMan : BasicAI
    {
        public OldMan()
        {
            mMind = new OldManMind(this);
        }
    }
}
