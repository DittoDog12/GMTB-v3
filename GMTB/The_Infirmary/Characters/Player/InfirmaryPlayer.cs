using GMTB.Entities;
using GMTB.InputSystem;
using GMTB.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace The_Infirmary.Characters.Player
{
    class InfirmaryPlayer : GMTB.Entities.Player, AITarget
    {
        #region Data Members
        private string mFacingDirection;
        #endregion


        #region Constructor
        public InfirmaryPlayer()
        {
            mFrames = 8;
            mColumns = 8;
            mInterval = 75f;
        }
        #endregion

        #region Methods
        public override void setVars(string _path, IContent_Manager _cm)
        {
            base.setVars(_path, _cm);
            if (_path == "Characters/Player/walkR")
                mFacingDirection = "right";
            else if (_path == "Characters/Player/walkL")
                mFacingDirection = "left";
        }
        public override void OnMoveInput(object _source, InputEvent _args)
        {
            base.OnMoveInput(_source, _args);
            switch (_args.currentKey)
            {
                case Keybindings.Right:
                    if (mFacingDirection == "left")
                    {
                        mFacingDirection = "right";
                        mTexturename = "Characters/Player/walkR";

                    }
                    mMoving = true;
                    break;
                case Keybindings.Left:
                    if (mFacingDirection == "right")
                    {
                        mFacingDirection = "left";
                        mTexturename = "Characters/Player/walkL";
                    }
                    mMoving = true;
                    break;
                case Keybindings.Released:
                default:
                    mCurrentFrame = 0;
                    mMoving = false;
                    break;
            }
        }
        public override void Draw(SpriteBatch _spriteBatch, GameTime _gameTime)
        {
            if (mMoving)
                IncrementFrame(_gameTime);
            base.Draw(_spriteBatch, _gameTime);

            if (mTexturename != mTexture.Name)
                mTexture = mContentManager.ApplyTexture(mTexturename);

        }
        #endregion
    }
}
