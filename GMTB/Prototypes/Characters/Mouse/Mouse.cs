using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMTB.Interfaces;
using GMTB.Entities.AI;
using Microsoft.Xna.Framework;

namespace Prototypes.Characters.Mouse
{
    public class Mouse : BasicAI
    {
        #region Data Members

        #endregion

        #region Constructor
        public Mouse()
        {
            mMind = new MouseMind(this);
        }
        #endregion

        #region Methods

        #endregion
    }
}
