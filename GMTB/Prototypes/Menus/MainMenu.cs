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
    public class MainMenu : Menu
    {
        #region Data Members
        private Texture2D startButton;
        private Vector2 startPosition;

        private Texture2D exitButton;
        private Vector2 exitPosition;

        #endregion

        #region Constructor
        public MainMenu(string _name) : base(_name)
        {

        }
        #endregion

        #region Methods
        public override void Initialize(IServiceLocator _sl)
        {
            base.Initialize(_sl);
            startPosition = new Vector2(Global.ScreenSize.X / 4, Global.ScreenSize.Y - 75);
            startButton = mContentManager.ApplyTexture("start");
            exitPosition = new Vector2(Global.ScreenSize.X - (Global.ScreenSize.X / 4), Global.ScreenSize.Y - 75);
            exitButton = mContentManager.ApplyTexture("exit");
            mBackgroundManager.ChangeBackground("MainMenu");
        }
        public override void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Begin();
            _spriteBatch.Draw(startButton, startPosition, Color.White);
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

            Rectangle _startPos = new Rectangle(startPosition.ToPoint(), new Point(startButton.Width, startButton.Height));
            Rectangle _exitPos = new Rectangle(exitPosition.ToPoint(), new Point(exitButton.Width, exitButton.Height));

            if (_mousePos.Intersects(_startPos))
            {
                mLevelManger.LoadLevel("L1");
                base.CloseMenu();
                Global.GameState = Global.availGameStates.Playing;
            }
            else if (_mousePos.Intersects(_exitPos))
                Global.GameState = Global.availGameStates.Exiting;
        }
        #endregion
    }
}
