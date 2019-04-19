using GMTB.Entities;
using GMTB.InputSystem;
using GMTB.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            
        }
        #endregion

        #region Methods
        public override void setVars(string _path, IContent_Manager _cm)
        {
            base.setVars(_path, _cm);
            if (_path == "Characters/Player/playerR")
                mFacingDirection = "right";
            else if (_path == "Characters/Player/playerL")
                mFacingDirection = "left";
            ChangeTexture();
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
                        ChangeTexture();
                    }
                    break;
                case Keybindings.Left:
                    if (mFacingDirection == "right")
                    {
                        mFacingDirection = "left";
                        ChangeTexture();
                    }
                    break;
                default:
                    break;
            }
        }
        public void ChangeTexture()
        {
            switch (mFacingDirection)
            {
                case "right":
                    mTexture = mContentManager.ApplyTexture("Characters/Player/playerR");
                    break;
                case "left":
                    mTexture = mContentManager.ApplyTexture("Characters/Player/playerL");
                    break;
                default:
                    break;
            }
        }
        #endregion
    }
}
