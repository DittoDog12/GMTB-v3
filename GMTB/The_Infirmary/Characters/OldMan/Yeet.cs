using GMTB.Abstracts;
using GMTB.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using GMTB.CollisionSystem;
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
        /// <param name="_mind">Reference to the mind</param>
        public Yeet(IAIMind _mind): base(_mind)
        {
            mJumpForce = -9f;
            mJumping = true;

        }
        public override void Reactivate()
        {
            base.Reactivate();
            mMind.MySelf.Texturename = "Characters/OldMan/jumpR";
            // Stop collision detection running right away
            mJumping = true;
            // Reset max jump reached
            mMaxReached = false;
            // Calculate the coordinates of the current jump max
            mJumpMax = mMind.MySelf.Position.Y - mJumpHeight;
            // Set animation frames
            mAnimation.Frames = 5;
            mAnimation.Columns = 5;
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
            mJumpVector.X = 7f;
            // If not at top of jump, continue jumping
            if (!mMaxReached)
                mJumpVector.Y = mJumpForce;
            // If at top of jump, stop jumping
            if (mMind.MySelf.Position.Y <= mJumpMax)
            {
                mMaxReached = true;
                mJumpVector.Y = 0;
            }
            mMind.MySelf.ApplyForce(mJumpVector);
            // Set toggle to allow collision detection to resume
            mJumping = false;

            IAnimation asInterface = mMind.MySelf as IAnimation;
            if (asInterface != null)
            {
                if (asInterface.Frame >= 2 && !mMaxReached)
                    asInterface.Frame = 2;
                else if (asInterface.Frame <= 2 && mMaxReached)
                    asInterface.Frame = 3;
            }
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
            mMind.ChangeState("walk");
        }
    }
}
