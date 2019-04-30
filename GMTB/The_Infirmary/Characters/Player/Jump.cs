using GMTB.Abstracts;
using GMTB.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Infirmary.Characters.Player
{
    public class Jump : State
    {
        public Jump(IPlayerMind _mind) : base(_mind)
        {
        }

        public override void Update(GameTime _gameTime)
        {
            throw new NotImplementedException();
        }
    }
}
