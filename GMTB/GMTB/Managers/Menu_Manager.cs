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
        private IServiceLocator mServiceLocator;
        #endregion
        #region Constructor
        public Menu_Manager(IServiceLocator _sl, IDictionary<string, IMenu> _menus)
        {
            mServiceLocator = _sl;
            mInputManager = mServiceLocator.GetService<IInput_Manager>();
            mInputManager.Sub_Esc(OnEsc);
            mMenus = _menus;
        }
        #endregion
        #region Methods
        public void InitializeMenus()
        {
            foreach (KeyValuePair<string, IMenu> _menu in mMenus)
            {
                _menu.Value.Initialize(mServiceLocator);
            }
        }
        public void ActivateMenu(string _targetMenu)
        {
            mActiveMenu = mMenus[_targetMenu];
            mActiveMenu.Subscribe();
        }
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
                    ActivateMenu("pause");
                    Global.GameState = Global.availGameStates.Menu;
                }
                //else if (Global.GameState == Global.availGameStates.Menu)
                //    Global.GameState = Global.availGameStates.Resuming;
            }
        }
        #endregion
    }
}
