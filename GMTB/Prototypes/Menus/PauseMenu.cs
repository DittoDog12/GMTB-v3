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

namespace Prototypes.Menus
{
    public class PauseMenu : Menu
    {
        #region Data Members
        private Texture2D resumeButton;
        private Vector2 resumePosition;

        private Texture2D exitButton;
        private Vector2 exitPosition;

        #endregion
        #region Constructor
        public PauseMenu(string _name) : base(_name)
        {

        }
        #endregion

        #region Methods
        public override void Initialize(IServiceLocator _sl, Camera2D _cam)
        {
            base.Initialize(_sl, _cam);
            resumePosition = new Vector2(Global.ScreenSize.X / 4, Global.ScreenSize.Y - 75);
            resumeButton = mContentManager.ApplyTexture("resume");
            exitPosition = new Vector2(Global.ScreenSize.X - (Global.ScreenSize.X / 4), Global.ScreenSize.Y - 75);
            exitButton = mContentManager.ApplyTexture("exit");
            //mBackgroundManager.ChangeBackground("MainMenu");
        }
        public override void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Begin();
            _spriteBatch.Draw(resumeButton, resumePosition, Color.White);
            _spriteBatch.Draw(exitButton, exitPosition, Color.White);
            _spriteBatch.End();
        }
        public override void Update(GameTime _gameTime)
        {
            //throw new NotImplementedException();
        }
        public override void OnClick(object source, MouseEvent args)
        {
            base.OnClick(source, args);

            Rectangle _mousePos = new Rectangle(args.currentPos.ToPoint(), new Point(10));

            Rectangle _resumePos = new Rectangle(resumePosition.ToPoint(), new Point(resumeButton.Width, resumeButton.Height));
            Rectangle _exitPos = new Rectangle(exitPosition.ToPoint(), new Point(exitButton.Width, exitButton.Height));

            if (_mousePos.Intersects(_resumePos))       
                Global.GameState = Global.availGameStates.Resuming;
            else if (_mousePos.Intersects(_exitPos))
                Global.GameState = Global.availGameStates.Exiting;
        }
        
        #endregion
    }
}
