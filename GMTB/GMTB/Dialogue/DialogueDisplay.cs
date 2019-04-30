using GMTB.Interfaces;
using GMTB.InputSystem;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMTB.Dialogue
{
    public class DialogueDisplay : IDialogue
    {
        #region Data Members
        private string[] mLines;
        private int mCurrLine;
        private bool mRunning;
        private float mTimer;
        private float mInterval;
        private IDialogueBox mDialogueBox;
        private IInput_Manager mInputManager;
        private IContent_Manager mContentManager;
        private Texture2D mArt;
        private string mArtpath;
        private Vector2 mArtPos;
        #endregion

        #region Constructor
        public DialogueDisplay(IServiceLocator _sl, string[] _lines, string _path, Vector2 _pos)
        {
            mLines = _lines;

            mInterval = 3000f;
            mTimer = 0f;
            mDialogueBox = new DialogueBox(_sl, new Vector2(50, Global.ScreenSize.Y - 50));
            mInputManager = _sl.GetService<IInput_Manager>();
            mContentManager = _sl.GetService<IContent_Manager>();
            mArtpath = _path;
            mArtPos = _pos;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Begins dialogue routine
        /// </summary>
        public void Begin()
        {
            mArt = mContentManager.ApplyTexture(mArtpath);
            // Subscribe to the Space Input Event
            mInputManager.Sub_Space(OnSpace);
            // Set the running bool to true
            mRunning = true;
        }
        /// <summary>
        /// Draw Text on screen
        /// </summary>
        /// <param name="_spiteBatch"> SpriteBatch </param>
        /// <param name="_gameTime"> GameTime </param>
        public void Draw(SpriteBatch _spiteBatch, GameTime _gameTime)
        {
            mCurrLine = 0;
            // Create rectangle to position the full character art
            Rectangle _artRect = new Rectangle(mArtPos.ToPoint(), new Point(mArt.Width, mArt.Height));
            // While there are lines to display and the running variable is active
            while (mCurrLine < mLines.Length && mRunning)
            {
                // Update the internal timer
                mTimer += (float)_gameTime.ElapsedGameTime.TotalMilliseconds;
                // Pass the current line to the Dialogue Box
                mDialogueBox.Draw(_spiteBatch, mLines[mCurrLine]);
                // Draw thefull character Art
                _spiteBatch.Draw(mArt, _artRect, Color.White);
                // If the timer is reached move to next line and update timer.
                if (mTimer >= mInterval)
                {
                    mCurrLine++;
                    mTimer = 0;
                }
            }
            // At end of dialogue reset the running bool to false;
            mRunning = false;
            // Unsubscribe from the Input Event
            mInputManager.Un_Space(OnSpace);
        }
        public void OnSpace(object _source, InputEvent _args)
        {
            // If space pressed, increment the line and reset the timer
            if (_args.currentKey == Keybindings.Jump)
            {
                mCurrLine++;
                mTimer = 0;
            }
                
        }
        #endregion
    }
}
