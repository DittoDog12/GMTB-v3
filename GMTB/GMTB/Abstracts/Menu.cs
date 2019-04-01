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
    public abstract class Menu : IMenu
    {
        #region Data Members
        //protected ILevel_Manager mLevelManager;
        protected IServiceLocator mServiceLocator;
        protected IInput_Manager mInputManager;
        protected IBackground_Manager mBackgroundManager;
        protected IEntity_Manager mEntityManager;
        protected IContent_Manager mContentManager;
        protected ILevel_Manager mLevelManger;

        protected Texture2D mBackgroundTexture;

        protected Vector2 mMousePos;

        protected IDictionary<int, IPhysicalEntity> mButtons;

        protected string mName;
        #endregion

        #region Accessors
        public Texture2D Texture
        {
            get { return mBackgroundTexture; }
        }
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
        public virtual void Initialize(IServiceLocator _sl)
        {
            mServiceLocator = _sl;
            mInputManager = mServiceLocator.GetService<IInput_Manager>();
            mBackgroundManager = mServiceLocator.GetService<IBackground_Manager>();
            mEntityManager = mServiceLocator.GetService<IEntity_Manager>();
            mContentManager = mServiceLocator.GetService<IContent_Manager>();
            mLevelManger = mServiceLocator.GetService<ILevel_Manager>();

            //Subscribe();
        }
        public abstract void Update(GameTime _gameTime);
        public abstract void Draw(SpriteBatch _spriteBatch);
        protected virtual void CloseMenu()
        {
            mInputManager.Un_Mouse(OnClick);
            mInputManager.Un_Esc(OnEsc);
            //foreach (KeyValuePair<int, IPhysicalEntity> _keyPair in mButtons)
            //    mEntityManager.DestroyEntity(_keyPair.Key);
        }
        public virtual void OnClick(object source, MouseEvent args)
        {
            if (args.currentKey == Keybindings.Click)
                mMousePos = args.currentPos;
        }
        public virtual void OnEsc(object source, InputEvent args)
        {
            if (args.currentKey == Keybindings.Pause)
                CloseMenu();
        }
        public virtual void Subscribe()
        {
            mInputManager.Sub_Mouse(OnClick);
            mInputManager.Sub_Esc(OnEsc);
        }
        #endregion
    }
}
