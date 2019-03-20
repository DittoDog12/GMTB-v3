using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMTB.InputSystem;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Prototypes.Characters
{
    public class Player : GMTB.Entities.Player
    {
        #region Constructor
        public Player()
        {
            mFrames = 8;
            mRows = 1;
            mColumns = 8;
            mInterval = 75f;
        }
        #endregion

        #region Methods
        public override void OnMoveInput(object _source, InputEvent _args)
        {
            base.OnMoveInput(_source, _args);
            switch (_args.currentKey)
            {
                case Keybindings.Down:
                    break;
                case Keybindings.Up:
                    break;
                case Keybindings.Right:
                    mTexturename = "playerR";
                    mMoving = true; 
                    break;
                case Keybindings.Left:
                    mTexturename = "playerL";
                    mMoving = true;
                    break;
                // If Keybinding is released, or keybinding is not recognised, stop moving
                case Keybindings.Released:
                default:
                    mCurrentFrame = 1;
                    mMoving = false;
                    break;
            }


        }
        public override void Draw(SpriteBatch _spriteBatch, GameTime _gameTime)
        {
            if (mMoving)
                IncrementFrame(_gameTime);
            base.Draw(_spriteBatch,  _gameTime);

            if (mTexturename != mTexture.Name)
                    mContentManager.ApplyTexture(mTexturename, this);

        }
        #endregion
    }
}
