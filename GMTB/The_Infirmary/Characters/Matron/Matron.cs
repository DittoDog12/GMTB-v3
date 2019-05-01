using GMTB.Entities.AI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Infirmary.Characters.Matron
{
    /// <summary>
    /// Matron AI
    /// </summary>
    class Matron : BasicAI
    {
        /// <summary>
        /// Main Constructor
        /// Creates the Mind
        /// </summary>
        public Matron()
        {
            mMind = new MatronMind(this);
        }
    }
}
