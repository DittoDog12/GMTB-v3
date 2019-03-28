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

        protected Texture2D mBackgroundTexture;

        protected Vector2 mMousePos;

        protected IDictionary<int, IPhysicalEntity> mButtons;
        #endregion

        #region Accessors
        public Texture2D Texture
        {
            get { return mBackgroundTexture; }
        }
        #endregion

        #region Constructor
        public Menu(IServiceLocator _sl, IInput_Manager _im, IBackground_Manager _bm, IEntity_Manager _em)
        {
            mServiceLocator = _sl;
            mInputManager = _im;
            mBackgroundManager = _bm;
            mEntityManager = _em;

            mInputManager.Sub_Mouse(OnClick);
            mInputManager.Sub_Esc(OnEsc);
        }
        #endregion

        #region Methods
        public abstract void Update(GameTime _gameTime);
        public abstract void Draw(SpriteBatch _spriteBatch);
        protected virtual void CloseMenu()
        {
            mInputManager.Un_Mouse(OnClick);
            mInputManager.Un_Esc(OnEsc);
            foreach (KeyValuePair<int, IPhysicalEntity> _keyPair in mButtons)
                mEntityManager.DestroyEntity(_keyPair.Key);
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
        #endregion
    }
}
