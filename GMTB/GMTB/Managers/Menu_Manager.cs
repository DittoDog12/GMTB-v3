using GMTB.InputSystem;
using GMTB.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMTB.Managers
{
    public class Menu_Manager : IMenu_Manager
    {
        #region Data Members
        private IDictionary<string, IMenu> mMenus;
        private IMenu mActiveMenu;
        private IInput_Manager mInputManager;
        #endregion
        #region Constructor
        public Menu_Manager(IInput_Manager _im, IDictionary<string, IMenu> _menus)
        {
            mInputManager = _im;
            mInputManager.Sub_Esc(OnEsc);
            mMenus = _menus;
        }
        #endregion
        #region Methods
        public void Update(GameTime _gameTime)
        {
            mActiveMenu.Update(_gameTime);
        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            mActiveMenu.Draw(_spriteBatch);
        }
        public void OnEsc(object source, InputEvent args)
        {
            // When escape is pressed and the game is playing, pause the game, otherwise resume it
            if (args.currentKey == Keybindings.Pause)
            {
                if (Global.GameState == Global.availGameStates.Playing)
                {
                    mActiveMenu = mMenus["pause"];
                    Global.GameState = Global.availGameStates.Paused;
                }
                else if (Global.GameState == Global.availGameStates.Paused)
                    Global.GameState = Global.availGameStates.Resuming;
            }
        }
        #endregion
    }
}
