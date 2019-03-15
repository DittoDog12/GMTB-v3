using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMTB.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GMTB.Managers
{
    public class Background_Manager : IBackground_Manager
    {
        #region Data Members
        private IContent_Manager mContentManager;
        private Texture2D mBackground;
        #endregion

        #region Accessors
        public Texture2D Texture
        {
            set { mBackground = value; }
        }
        #endregion

        #region Constructor
        public Background_Manager(IContent_Manager _cm)
        {
            mContentManager = _cm;
        }
        #endregion

        #region Methods
        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(mBackground, new Rectangle(0, 0, 800, 480), Color.White);
        }
        public void ChangeBackground(string _newBackground)
        {
            mContentManager.ApplyTexture(_newBackground, this);
        }

        #endregion
    }
}
