using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using GMTB.Interfaces;

namespace GMTB.Entities
{
    class Player : Entity, IPlayer
    {
        #region Methods
        public Vector2 GetPos()
        {
            return mPosition;
        }
        #endregion
    }
}
