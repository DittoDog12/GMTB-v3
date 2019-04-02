using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;
using GMTB.Interfaces;

namespace GMTB.Managers
{
    public class Content_Manager : IContent_Manager
    {
        #region Data Members
        private ContentManager mContent;
        #endregion

        #region Constructor
        public Content_Manager(ContentManager _content, string _Root)
        {
            mContent = _content;
            mContent.RootDirectory = _Root;
        }
        #endregion

        #region Methods
        public Texture2D ApplyTexture(string _tex)
        {
           return mContent.Load<Texture2D>(_tex);
        }
        public SoundEffect LoadSound(string _file)
        {
            return mContent.Load<SoundEffect>(_file);
        }
        public SpriteFont LoadFont(string _font)
        {
            return mContent.Load<SpriteFont>(_font);
        }
        #endregion
    }
}
