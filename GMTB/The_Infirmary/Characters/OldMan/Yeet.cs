using GMTB.Abstracts;
using GMTB.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Infirmary.Characters.OldMan
{
    /// <summary>
    /// Old Man Burt Yeet (Jumping) Behaviour
    /// </summary>
    public class Yeet : State
    {
        /// Velocity to jump at
        private Vector2 mJumpVelocity;

        /// <summary>
        /// Main Constructor
        /// </summary>
        /// <param name="_mind">Reference to the mind</param>
        public Yeet(IAIMind _mind): base(_mind)
        {
            mJumpVelocity = new Vector2(5f, -5f);
            
        }
        public override void Reactivate()
        {
            base.Reactivate();
            mMind.MySelf.Texturename = "Characters/OldMan/jumpR";
        }
        /// <summary>
        /// Main Draw Loop
        /// </summary>
        /// <param name="_spriteBatch">Reference to the SpriteBatch</param>
        /// <param name="_gameTime">Reference to current GameTime</param>
        public override void Draw(SpriteBatch _spriteBatch, GameTime _gameTime)
        {
            
        }

        /// <summary>
        /// Main Update Loop
        /// </summary>
        /// <param name="_gameTime">Reference to the current GameTime</param>
        public override void Update(GameTime _gameTime)
        {
            mMind.MySelf.ApplyForce(mJumpVelocity);
            IAnimation asInterface = mMind.MySelf as IAnimation;
            if (asInterface != null)
            {
                if (asInterface.Frame >= 3)
                    asInterface.Frame = 3;
            }
        }
    }
}
