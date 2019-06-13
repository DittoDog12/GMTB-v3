using GMTB.Abstracts;
using GMTB.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Infirmary.Characters.Nurse2
{
    /// <summary>
    /// Nurse Idle State
    /// </summary>
    class Idle : State
    {
        private float mTriggerDistance = 150f;

        public Idle(IAIMind _mind) : base(_mind)
        {
        }
        /// <summary>
        /// Initializes the Behaviour, sets up all variables required from the start
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();
            mAnimation.Frames = 1;
            mAnimation.Columns = 1;
        }
        /// <summary>
        /// Resests any settings that may have been changed by other behaviours
        /// </summary>
        public override void Reactivate()
        {
            mMind.MySelf.Moving = false;

            mAnimation.Frames = 1;
            mAnimation.Columns = 1;
            mAnimation.Frame = 0;

            if (mMind.MySelf.CurrentDirection == GMTB.Entities.FacingDirection.Right)
                mMind.MySelf.Texturename = "Characters/Nurse2/standR";
            else if (mMind.MySelf.CurrentDirection == GMTB.Entities.FacingDirection.Left)
                mMind.MySelf.Texturename = "Characters/Nurse2/standL";

            base.Reactivate();
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
            if (mMind.Target != null)
            {
                Vector2 v1 = new Vector2(mMind.Target.Position.X, 0);
                Vector2 v2 = new Vector2(mMind.MySelf.Position.X, 0);
                float _distance = Vector2.Distance(v1, v2);
                if (_distance <= mTriggerDistance)
                    ChangeState("persue");
            }
        }
    }
}
