using GMTB.Abstracts;
using GMTB.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Infirmary.Characters.Doctor
{
    /// <summary>
    /// Doctor Walk Behaviour
    /// </summary>
    public class Walk : State
    {
        private float mSpeed = 3f;
        /// <summary>
        /// Main Constructor
        /// </summary>
        /// <param name="_mind">Reference to the Mind</param>
        public Walk(IAIMind _mind) : base(_mind)
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
        /// <param name="_gameTime">Reference to the GameTime</param>
        public override void Update(GameTime _gameTime)
        {
            if (mMind.MySelf.CurrentDirection == GMTB.Entities.FacingDirection.Right)
                mMind.MySelf.Texturename = "Characters/Doctor/walkR";
            else if (mMind.MySelf.CurrentDirection == GMTB.Entities.FacingDirection.Left)
                mMind.MySelf.Texturename = "Characters/Doctor/walkL";
            mMind.MySelf.Moving = true;

            Vector2 _dest = Vector2.Zero;
            mMind.MySelf.Moving = true;
            // Check current level and set target destination appropriately
            if (mMind.MySelf.ServiceLocator.GetService<ILevel_Manager>().CurrentLevelID == "L4")
                _dest = new Vector2(80, 260);
            else if (mMind.MySelf.ServiceLocator.GetService<ILevel_Manager>().CurrentLevelID == "L6")
                _dest = new Vector2(1672, 310);

            // Update Physical Body destination
            mMind.MySelf.Destination = _dest;
            // Move to destination
            mMind.MySelf.ApplyForce(PlotPath(_dest));            
        }
        /// <summary>
        /// Path plotting
        /// </summary>
        /// <returns>Direction to the destination</returns>
        private Vector2 PlotPath(Vector2 _dest)
        {
            Vector2 _rtnval;

            // Calcualte the vector to get to the current destination
            _rtnval = _dest - mMind.MySelf.Position;
            _rtnval.Normalize();
            return _rtnval * mSpeed;
        }
    }
}
