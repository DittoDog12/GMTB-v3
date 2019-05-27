using GMTB.Abstracts;
using GMTB.CollisionSystem;
using GMTB.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Infirmary.Characters.Player
{
    /// <summary>
    /// Player Jump Behaviour
    /// </summary>
    public class Jump : State
    {
        /// Vector to jump along
        private Vector2 mJumpVector;
        /// Force of the jump
        private float mJumpForce;
        /// Jumping or not, used to stop the collision detection triggering too early
        private bool mJumping = true;
        /// Max height reached
        private bool mMaxReached = false;
        /// Max Height of jump
        private float mJumpHeight = 160f;
        /// Max Height of current Jump
        private float mJumpMax;

        /// <summary>
        /// Main Constructor
        /// </summary>
        /// <param name="_mind">Reference to the Mind</param>
        public Jump(IPlayerMind _mind) : base(_mind)
        {
            mJumpForce = -6f;
            mJumping = true;
        }
        /// <summary>
        /// Reactivate the Behaviour
        /// </summary>
        public override void Reactivate()
        {
            // Stop collision detection running right away
            mJumping = true;
            // Reset max jump reached
            mMaxReached = false;
            // Calculate the coordinates of the current jump max
            mJumpMax = mPMind.MySelf.GetPos().Y - mJumpHeight;
        }
        /// <summary>
        /// Main Update Loop
        /// </summary>
        /// <param name="_gameTime">Reference to the current GameTime</param>
        public override void Update(GameTime _gameTime)
        {
            // If not at top of jump, continue jumping
            if (!mMaxReached)   
                mJumpVector.Y = mJumpForce;
            // If at top of jump, stop jumping
            if (mPMind.MySelf.GetPos().Y <= mJumpMax)
            {
                mMaxReached = true;
                mJumpVector.Y = 0;
            }
                
            
            mPMind.MySelf.ApplyForce(mJumpVector);
            // Set toggle to allow collision detection to resume
            mJumping = false;
        }
        /// <summary>
        /// Non physical Collision Detection
        /// Used to see if the player has landed
        /// </summary>
        /// <param name="_obj">Other Object Collided with</param>
        public override void Collision(ICollidable _obj)
        {
            //IStaticObject asInterface = _obj as IStaticObject;
            //if (asInterface.TextureName == "floor" && !mJumping)
                mPMind.ChangeState("walk");
        }

        public override void Draw(SpriteBatch _spriteBatch, GameTime _gameTime)
        {
            
        }
    }
}
