using GMTB.Entities.AI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using GMTB.Interfaces;

namespace The_Infirmary.Characters.Nurse
{
    /// <summary>
    /// Nurse AI
    /// </summary>
    public class Nurse : BasicAI
    {
        /// <summary>
        /// Main Constructor
        /// </summary>
        public Nurse()
        {
            mMind = new NurseMind(this);
            mFrames = 8;
            mColumns = 8;
            mInterval = 75f;
        }
        public override void setVars(string _path, IContent_Manager _cm)
        {
            base.setVars(_path, _cm);
            if (_path == "Characters/Nurse1/standR")
                mCurrDir = GMTB.Entities.FacingDirection.Right;
            else if (_path == "Characters/Nurse1/standL")
                mCurrDir = GMTB.Entities.FacingDirection.Left;
        }
        /// <summary>
        /// Main Draw Loop
        /// </summary>
        /// <param name="_spriteBatch">Reference to the SpriteBatch</param>
        /// <param name="_gameTime">Reference to the current GameTime</param>
        public override void Draw(SpriteBatch _spriteBatch, GameTime _gameTime)
        {
            if (mMoving)
                IncrementFrame(_gameTime);
            base.Draw(_spriteBatch, _gameTime);
        }
        /// <summary>
        /// Main Update Loop
        /// </summary>
        /// <param name="_gameTime">Reference to the current GameTime</param>
        public override void Update(GameTime _gameTime)
        {
            base.Update(_gameTime);
        }
    }
}
