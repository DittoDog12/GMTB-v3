using GMTB.Entities.AI;
using GMTB.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototypes.Characters.Mouse
{
    public class Mouse : BasicAI
    {
        #region Data Members
        
        #endregion

        #region Accessors
        
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
