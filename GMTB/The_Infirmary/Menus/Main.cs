﻿using GMTB;
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
    public class Main : Menu
    {
        #region Data Members
        private Texture2D startButton;
        private Vector2 startPosition;

        private Texture2D exitButton;
        private Vector2 exitPosition;

        #endregion

        #region Constructor
        public Main(string _name) : base(_name)
        {

        }
        #endregion

        #region Methods
        public override void Initialize(IServiceLocator _sl, Camera2D _cam)
        {
            base.Initialize(_sl, _cam);
            startPosition = new Vector2(900, 345);
            //startButton = mContentManager.ApplyTexture("start");
            exitPosition = new Vector2(910, 500);
            //exitButton = mContentManager.ApplyTexture("exit");
            mBackgroundManager.ChangeBackground("Menus/title");
            mBackgroundManager.ChangePosition(240, 180);
        }
        public override void Draw(SpriteBatch _spriteBatch)
        {
            //_spriteBatch.Draw(startButton, startPosition, Color.White);
            //_spriteBatch.Draw(exitButton, exitPosition, Color.White);
        }
        public override void Update(GameTime _gameTime)
        {
            //throw new NotImplementedException();
            mCam.Position = new Vector2(680, 500);
        }
        public override void OnClick(object source, MouseEvent args)
        {
            base.OnClick(source, args);

            Rectangle _mousePos = new Rectangle(args.currentPos.ToPoint(), new Point(10));

            Rectangle _startPos = new Rectangle(startPosition.ToPoint(), new Point(135, 40));
            Rectangle _exitPos = new Rectangle(exitPosition.ToPoint(), new Point(100, 40));

            if (_mousePos.Intersects(_startPos))
            {
                mLevelManger.LoadLevel("L1", false);
                base.CloseMenu();
                Global.GameState = Global.availGameStates.Playing;
            }
            else if (_mousePos.Intersects(_exitPos))
                Global.GameState = Global.availGameStates.Exiting;
        }
        public override void OnEsc(object source, InputEvent args)
        {
            if (args.currentKey == Keybindings.Pause)
                Global.GameState = Global.availGameStates.Exiting;
        }
        #endregion
    }
}
