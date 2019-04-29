using GMTB.Abstracts;
using GMTB.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Infirmary.Characters.Doctor
{
    public class Walk : State
    {
        public Walk(IMind _mind) : base(_mind)
        {

        }

        public override void Update(GameTime _gameTime)
        {
            mMind.MySelf.Moving = true;
            mMind.MySelf.ApplyForce(PlotPath());
        }

        private Vector2 PlotPath()
        {
            Vector2 _rtnval;

            // Calcualte the vector to get to the current destination
            _rtnval = mMind.MySelf.Target.Position - mMind.MySelf.Position;
            _rtnval.Normalize();

            return _rtnval;
        }
    }
}
