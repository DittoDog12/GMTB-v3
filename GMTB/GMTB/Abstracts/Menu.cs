using GMTB.InputSystem;
using GMTB.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMTB.Abstracts
{
    /// <summary>
    /// Abstract Class for the Menus to inherit from
    /// </summary>
    public abstract class Menu : IMenu
    {
        #region Data Members
        //protected ILevel_Manager mLevelManager;
        /// Service Locator Reference
        protected IServiceLocator mServiceLocator;
        /// Input Manager Reference
        protected IInput_Manager mInputManager;
        /// Background Manager Reference
        protected IBackground_Manager mBackgroundManager;
        /// Entity Manager Reference
        protected IEntity_Manager mEntityManager;
        /// Content Manager Reference
        protected IContent_Manager mContentManager;
        /// Level Manager Reference
        protected ILevel_Manager mLevelManger;

        /// Background Texture to display
        protected Texture2D mBackgroundTexture;

        /// Vector to hold Mouse click positiob
        protected Vector2 mMousePos;

        //protected IDictionary<int, IPhysicalEntity> mButtons;

        /// Menu Name
        protected string mName;

        /// Reference to the 2D camera if needed
        protected Camera2D mCam;
        #endregion

        #region Accessors
        /// Texture Accessor
        public Texture2D Texture
        {
            get { return mBackgroundTexture; }
        }
        /// Menu Name Accessor
        public string Name
        {
            get { return mName; }
        }
        #endregion

        #region Constructor
        public Menu(string _name)
        {
            mName = _name;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Allows the Menu to initialize itself
        /// Sets up references to the managers and camera
        /// </summary>
        /// <param name="_sl">Reference to the service locator</param>
        /// <param name="_cam">Reference to the 2D Camera</param>
        public virtual void Initialize(IServiceLocator _sl, Camera2D _cam)
        {
            mServiceLocator = _sl;
            mInputManager = mServiceLocator.GetService<IInput_Manager>();
            mBackgroundManager = mServiceLocator.GetService<IBackground_Manager>();
            mEntityManager = mServiceLocator.GetService<IEntity_Manager>();
            mContentManager = mServiceLocator.GetService<IContent_Manager>();
            mLevelManger = mServiceLocator.GetService<ILevel_Manager>();
            mCam = _cam;
            //Subscribe();
        }
        /// <summary>
        /// Abstract Update Method
        /// </summary>
        /// <param name="_gameTime">Reference to the current GameTime</param>
        public abstract void Update(GameTime _gameTime);
        /// <summary>
        /// Abstract Draw Method
        /// </summary>
        /// <param name="_spriteBatch">Reference to the main SpriteBatch</param>
        public abstract void Draw(SpriteBatch _spriteBatch);
        /// <summary>
        /// Closes the menu
        /// Unsubscribes from the Input Events
        /// </summary>
        protected virtual void CloseMenu()
        {
            mInputManager.Un_Mouse(OnClick);
            mInputManager.Un_Esc(OnEsc);
            //foreach (KeyValuePair<int, IPhysicalEntity> _keyPair in mButtons)
            //    mEntityManager.DestroyEntity(_keyPair.Key);
        }
        /// <summary>
        /// Mouse Click Event listener
        /// </summary>
        /// <param name="source">Event Source</param>
        /// <param name="args">Event Arguments</param>
        public virtual void OnClick(object source, MouseEvent args)
        {
            if (args.currentKey == Keybindings.Click)
                mMousePos = args.currentPos;
        }
        /// <summary>
        /// Escape Click Event listener
        /// </summary>
        /// <param name="source">Event Source</param>
        /// <param name="args">Event Arguments</param>
        public virtual void OnEsc(object source, InputEvent args)
        {
            if (args.currentKey == Keybindings.Pause)
                CloseMenu();
        }
        /// <summary>
        /// Input Event subscribers
        /// </summary>
        public virtual void Subscribe()
        {
            mInputManager.Sub_Mouse(OnClick);
            mInputManager.Sub_Esc(OnEsc);
        }
        #endregion
    }
}
