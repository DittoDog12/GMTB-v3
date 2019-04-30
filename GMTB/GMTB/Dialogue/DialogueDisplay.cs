﻿using GMTB.Interfaces;
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
    /// <summary>
    /// Dialogue Display System
    /// Entities with Dialogue will create a displayer and pass their lines into it
    /// Displayer will then create a renderer box and pass the lines to that when needed
    /// </summary>
    public class DialogueDisplay : IDialogue
    {
        #region Data Members
        /// Total Lines
        private string[] mLines;
        /// Current Line
        private int mCurrLine;
        /// Override to control wether or not to display text
        private bool mRunning;
        /// Timer to control automatic dialogue progression
        private float mTimer;
        /// Interval to progress dialogue
        private float mInterval;
        /// Reference to Dialogue Renderer box
        private IDialogueBox mDialogueBox;
        /// Reference to Input Manger
        private IInput_Manager mInputManager;
        /// Reference to Content Manager
        private IContent_Manager mContentManager;
        /// Texture to hold character art
        private Texture2D mArt;
        /// Character art texture path
        private string mArtpath;
        /// Position to render character art
        private Vector2 mArtPos;
        #endregion

        #region Constructor
        /// <summary>
        /// Main Constructor
        /// </summary>
        /// <param name="_sl">Reference to Service Locator</param>
        /// <param name="_lines">Lines to display</param>
        /// <param name="_path">Character art path</param>
        /// <param name="_pos">Character art position</param>
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
        /// <param name="_spiteBatch">Reference to main SpriteBatch</param>
        /// <param name="_gameTime">Reference to current GameTime</param>
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
        /// <summary>
        /// Space input event listener
        /// </summary>
        /// <param name="_source">Event Source</param>
        /// <param name="_args">Event Arguments</param>
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
