using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using GMTB.Interfaces;
using GMTB.InputSystem;
using GMTB.CollisionSystem;

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
                    ApplyForce(new Vector2(0, 3));
                    break;
                case Keybindings.Up:
                    ApplyForce(new Vector2(0, -3));
                    break;
                case Keybindings.Right:
                    ApplyForce(new Vector2(3, 0));
                    break;
                case Keybindings.Left:
                    ApplyForce(new Vector2(-3, 0));
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
