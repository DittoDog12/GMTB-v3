using GMTB.Abstracts;
using GMTB.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Infirmary.Characters.Matron
{
    /// <summary>
    /// Matron Persue state
    /// </summary>
    public class Persue : State
    {
        private float mSpeed = 2.75f;
        /// <summary>
        /// Main Constructor
        /// </summary>
        /// <param name="_mind">Reference to the mind</param>
        public Persue(IAIMind _mind) : base(_mind)
        {
        }
        public override void Reactivate()
        {
            base.Reactivate();
            IAnimation _animation = mMind.MySelf as IAnimation;
            _animation.Frames = 8;
            _animation.Columns = 8;
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
            if (mMind.MySelf.CurrentDirection == GMTB.Entities.FacingDirection.Right)
                mMind.MySelf.Texturename = "Characters/Matron/walkR";
            else if (mMind.MySelf.CurrentDirection == GMTB.Entities.FacingDirection.Left)
                mMind.MySelf.Texturename = "Characters/Matron/walkL";

            mMind.MySelf.Moving = true;
            mMind.MySelf.ApplyForce(PlotPath());
        }
        /// <summary>
        /// Plot a path
        /// </summary>
        /// <returns>Direction to the path</returns>
        private Vector2 PlotPath()
        {
            Vector2 _rtnval;

            // Calcualte the vector to get to the current destination
            _rtnval = mMind.MySelf.Target.Position - mMind.MySelf.Position;
            _rtnval.Normalize();

            return _rtnval * mSpeed;
        }
    }
}
