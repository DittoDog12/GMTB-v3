using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using GMTB.Interfaces;
using GMTB.InputSystem;
using GMTB.CollidableShapes;

namespace GMTB.Entities
{
    public class Player : RectangleShape, IPlayer
    {
        #region Constructor
        public Player()
        {
            mSpeed = 5f;
        }
        #endregion
        #region Methods
        public override void ConfigureInput(IInput_Manager im)
        {
            base.ConfigureInput(im);
            mInputManager.Sub_Move(OnMoveInput);

        }
        public Vector2 GetPos()
        {
            return mPosition;
        }
        public void OnMoveInput(object source, InputEvent args)
        {
            // Check the current keybinding in the event argument.
            // Apply force respectiveley
            switch (args.currentKey)
            {
                case Keybindings.Down:
                    mVelocity.Y = mSpeed * 1;
                    break;
                case Keybindings.Up:
                    mVelocity.Y = mSpeed * -1;
                    break;
                case Keybindings.Right:
                    mVelocity.X = mSpeed * 1;
                    break;
                case Keybindings.Left:
                    mVelocity.X = mSpeed * -1;
                    break;
                // If Keybinding is released, or keybinding is not recognised, stop moving
                case Keybindings.Released:
                default:
                    mVelocity = Vector2.Zero;
                    break;
            }
        }
        #endregion
    }
}
