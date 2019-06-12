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
    /// Old man Idle State
    /// </summary>
    public class Idle: State
    {
        private float mTriggerDistance = 100f;
        /// <summary>
        /// Main Constructor
        /// </summary>
        /// <param name="_mind">Reference to the Mind</param>
        public Idle(IAIMind _mind): base (_mind)
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
                Vector2 _dist = mMind.Target.Position - mMind.MySelf.Position;
                float _distance = _dist.Length();
                if (_distance < mTriggerDistance)
                    ChangeState("talk");
            }
        }
    }
}
