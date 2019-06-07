using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMTB.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GMTB.Managers
{
    /// <summary>
    /// Background Manager, controls the displaying of enviroments on the background
    /// </summary>
    public class Background_Manager : IBackground_Manager
    {
        #region Data Members
        /// Reference to the Content Manger
        private IContent_Manager mContentManager;
        /// Texture for leftmost background
        private Texture2D mBackground;
        /// Texture for rightmost background
        private Texture2D mBackground2;
        /// Store for X coordinate
        private int mXPos;
        /// Store for Y coordinate
        private int mYPos;
        #endregion

        #region Accessors
        ///// Accessor for Texture
        //public Texture2D Texture
        //{
        //    set { mBackground = value; }
        //}
        #endregion

        #region Constructor
        /// <summary>
        /// Main Constructor
        /// </summary>
        /// <param name="_cm">Reference to the Content Manger</param>
        public Background_Manager(IContent_Manager _cm)
        {
            mContentManager = _cm;
            mXPos = 0;
            mYPos = 75;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Main Draw Loop
        /// </summary>
        /// <param name="_spriteBatch">Reference to the SpriteBatch</param>
        /// <param name="_gameTime">Reference to the current GameTime</param>
        public void Draw(SpriteBatch _spriteBatch, GameTime _gameTime)
        {
            // Check background is valid and draw at position 0,50
            if (mBackground != null)
                _spriteBatch.Draw(mBackground, new Rectangle(mXPos, mYPos, mBackground.Width, mBackground.Height), Color.White);

            // Check second background is valid and draw at right hand end of first background
            if (mBackground2 != null)
                _spriteBatch.Draw(mBackground2, new Rectangle(mBackground2.Width, mYPos, mBackground2.Width, mBackground2.Height), Color.White);


        }
        /// <summary>
        /// Apply a new background
        /// </summary>
        /// <param name="_newBG"> Content path to the new background </param>
        public void ChangeBackground(string _newBG)
        {
            mBackground = mContentManager.ApplyTexture(_newBG);
        }
        /// <summary>
        /// Apply multiple backgrounds, ie if the main background is too big
        /// </summary>
        /// <param name="_newBG1"> Content path to left part of background </param>
        /// <param name="_newBG2"> Content path to right part of background </param>
        public void ChangeBackground(string _newBG1, string _newBG2)
        {
            ChangeBackground(_newBG1);
            mBackground2 = mContentManager.ApplyTexture(_newBG2);
        }
        /// <summary>
        /// Change the background position, used to render two backgrounds at once
        /// </summary>
        /// <param name="_x"> New X cooridinate </param>
        /// <param name="_y"> New Y Cooridinate </param>
        public void ChangePosition(int _x, int _y)
        {
            mXPos = _x;
            mYPos = _y;
        }
        /// <summary>
        /// Clear both backgrounds
        /// </summary>
        public void BlankBackgrounds()
        {
            mBackground = null;
            mBackground2 = null;
        }
        #endregion
    }
}
