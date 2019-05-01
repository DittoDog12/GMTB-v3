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
    /// <summary>
    /// Menu Manager, Controls loading, drawing and updating menus
    /// Also controls Escape key pausing and unpausing
    /// </summary>
    public class Menu_Manager : IMenu_Manager
    {
        #region Data Members
        /// Dictionary of menus
        private IDictionary<string, IMenu> mMenus;
        /// Active Menu
        private IMenu mActiveMenu;
        /// Reference to Input Manager
        private IInput_Manager mInputManager;
        /// Reference to the Service Locator
        private IServiceLocator mServiceLocator;
        /// Reference to the 2D Camera if needed
        private Camera2D mCam;
        #endregion
        #region Constructor
        /// <summary>
        /// Main Constructor
        /// </summary>
        /// <param name="_sl">Reference to the Service Locator</param>
        /// <param name="_menus">Pass all loaded menus here</param>
        public Menu_Manager(IServiceLocator _sl, IDictionary<string, IMenu> _menus)
        {
            mServiceLocator = _sl;
            mInputManager = mServiceLocator.GetService<IInput_Manager>();
            mInputManager.Sub_Esc(OnEsc);
            mMenus = _menus;
        }
        #endregion
        #region Methods
        /// <summary>
        /// Configure Camera if needed
        /// Menus will check if camera != null
        /// </summary>
        /// <param name="_cam"></param>
        public void ConfigureCamera(Camera2D _cam)
        {
            mCam = _cam;
        }
        /// <summary>
        /// Initialize all menus
        /// </summary>
        public void InitializeMenus()
        {
            foreach (KeyValuePair<string, IMenu> _menu in mMenus)
            {
                _menu.Value.Initialize(mServiceLocator, mCam);
            }
        }
        /// <summary>
        /// Activate a specified menu
        /// Subscribe the newly activate menu to it's input requirements
        /// </summary>
        /// <param name="_targetMenu">Menu to activate</param>
        public void ActivateMenu(string _targetMenu)
        {
            mActiveMenu = mMenus[_targetMenu];
            mActiveMenu.Subscribe();
        }
        /// <summary>
        /// Main Update Loop
        /// </summary>
        /// <param name="_gameTime">Reference to the current GameTime</param>
        public void Update(GameTime _gameTime)
        {
            mActiveMenu.Update(_gameTime);       
        }
        /// <summary>
        /// Main Draw Loop
        /// </summary>
        /// <param name="_spriteBatch">Reference to the SpriteBatch</param>
        public void Draw(SpriteBatch _spriteBatch)
        {
            mActiveMenu.Draw(_spriteBatch);
        }
        /// <summary>
        /// On Escape toggle
        /// Switches the gamestate between paused and playing
        /// Displays Pause meny when entering paused state
        /// </summary>
        /// <param name="source">Event Source</param>
        /// <param name="args">Event Arguments</param>
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
                else if (Global.GameState == Global.availGameStates.Menu)
                    Global.GameState = Global.availGameStates.Resuming;
            }
        }
        
        #endregion
    }
}
