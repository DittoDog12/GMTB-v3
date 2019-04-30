using GMTB.Abstracts;
using GMTB.CollisionSystem;
using GMTB.InputSystem;
using GMTB.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Infirmary.Characters.Player
{
    public class Walk : State
    {
        #region Data Members
        private bool mCanJump;
        private IInput_Manager mInputManager;
        #endregion
        public Walk(IPlayerMind _mind) : base(_mind)
        {

        }
        public void Initialize(IServiceLocator _sl)
        {
            base.Initialize();
            mInputManager = _sl.GetService<IInput_Manager>();
            Reactivate();
        }
        public override void Update(GameTime _gameTime)
        {
            mCanJump = false;
        }

        public override void Reactivate()
        {
            mInputManager.Sub_Space(OnSpace);
        }

        public void OnSpace(object source, InputEvent args)
        {
            if (mCanJump && args.currentKey == Keybindings.Jump)
            {
                mPMind.ChangeState("jump");
                mInputManager.Un_Space(OnSpace);
            }
                
        }
        public override void Collision(ICollidable _obj)
        {
            IStaticObject asInterface = _obj as IStaticObject;
            if (asInterface.TextureName == "blank")
                mCanJump = true;
        }
    }
}
