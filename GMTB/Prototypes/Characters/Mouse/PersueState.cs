using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMTB.Abstracts;
using GMTB.Interfaces;
using Microsoft.Xna.Framework;

namespace Prototypes.Characters.Mouse
{
    class PersueState : State
    {
        #region Constructor
        public PersueState(IMind _mind): base(_mind)
        {

        }
        #endregion

        #region Methods
        public override void Update(GameTime _gameTime)
        {
            // if collected cheese
            //ChangeState("idle");

            // if cat close
            //ChangeState("flee");
        }
        #endregion
    }
}
