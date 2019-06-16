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
    /// Doctor Idle Behaviour
    /// </summary>
    public class Idle : State
    {
        private float mTriggerDistance = 300f;

        /// <summary>
        /// Main Constructor
        /// </summary>
        /// <param name="_mind">Reference to the Mind</param>
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
                mMind.MySelf.Texturename = "Characters/Doctor/standR";
            else if (mMind.MySelf.CurrentDirection == GMTB.Entities.FacingDirection.Left)
                mMind.MySelf.Texturename = "Characters/Doctor/standL";

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
            mMind.MySelf.Moving = false;

            if (mMind.Target != null)
            {
                Vector2 _dist = mMind.Target.Position - mMind.MySelf.Position;
                float _distance = _dist.Length();
                if (_distance < mTriggerDistance)
                    ChangeState("walk");
            }
        }
    }
}
