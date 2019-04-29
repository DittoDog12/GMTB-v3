using GMTB;
using GMTB.Abstracts;
using GMTB.InputSystem;
using GMTB.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Infirmary.Menus
{
    public class Pause : Menu
    {
        #region Data Members
        //private Texture2D resumeButton;
        //private Vector2 resumePosition;

        //private Texture2D exitButton;
        //private Vector2 exitPosition;

        private Texture2D mPauseScreen;

        #endregion
        #region Constructor
        public Pause(string _name) : base(_name)
        {

        }
        #endregion

        #region Methods
        public override void Initialize(IServiceLocator _sl, Camera2D _cam)
        {
            base.Initialize(_sl, _cam);
            //resumePosition = new Vector2(Global.ScreenSize.X / 4, Global.ScreenSize.Y - 75);
            //resumeButton = mContentManager.ApplyTexture("resume");
            //exitPosition = new Vector2(Global.ScreenSize.X - (Global.ScreenSize.X / 4), Global.ScreenSize.Y - 75);
            //exitButton = mContentManager.ApplyTexture("exit");
            //mBackgroundManager.ChangeBackground("MainMenu");
            mPauseScreen = mContentManager.ApplyTexture("Menus/paused");
        }
        public override void Draw(SpriteBatch _spriteBatch)
        {
            //_spriteBatch.Draw(resumeButton, resumePosition, Color.White);
            //_spriteBatch.Draw(exitButton, exitPosition, Color.White);
            // Render the pause text over the main game, positioned center with the cameras present location
            _spriteBatch.Draw(mPauseScreen, new Rectangle((int)(mCam.Position.X - Global.ScreenSize.X /2), 
                (int)(mCam.Position.Y - Global.ScreenSize.Y / 2), (int)Global.ScreenSize.X, (int)Global.ScreenSize.Y), Color.White);
        }
        public override void Update(GameTime _gameTime)
        {
            //throw new NotImplementedException();
        }
        public override void OnClick(object source, MouseEvent args)
        {
            //base.OnClick(source, args);

            //Rectangle _mousePos = new Rectangle(args.currentPos.ToPoint(), new Point(10));

            //Rectangle _resumePos = new Rectangle(resumePosition.ToPoint(), new Point(resumeButton.Width, resumeButton.Height));
            //Rectangle _exitPos = new Rectangle(exitPosition.ToPoint(), new Point(exitButton.Width, exitButton.Height));

            //if (_mousePos.Intersects(_resumePos))
            //    Global.GameState = Global.availGameStates.Resuming;
            //else if (_mousePos.Intersects(_exitPos))
            //    Global.GameState = Global.availGameStates.Exiting;
        }

        #endregion
    }
}
