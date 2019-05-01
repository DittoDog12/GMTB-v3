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
    /// <summary>
    /// Content Manager, Accesses the Monogame Content Manager and loads all content when requested
    /// </summary>
    public class Content_Manager : IContent_Manager
    {
        #region Data Members
        /// Reference to the Monogame Content Manager
        private ContentManager mContent;
        #endregion

        #region Constructor
        /// <summary>
        /// Main Constructor
        /// </summary>
        /// <param name="_content">Reference to the Monogame Content Manager</param>
        /// <param name="_Root">Path to the Root of the Content Directory</param>
        public Content_Manager(ContentManager _content, string _Root)
        {
            mContent = _content;
            mContent.RootDirectory = _Root;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Load a texture
        /// </summary>
        /// <param name="tex">Path to texture</param>
        /// <returns>Loaded texture</returns>
        public Texture2D ApplyTexture(string _tex)
        {
           return mContent.Load<Texture2D>(_tex);
        }
        /// <summary>
        /// Load a sound
        /// </summary>
        /// <param name="_file">Path to Sound</param>
        /// <returns>Loaded Sound</returns>
        public SoundEffect LoadSound(string _file)
        {
            return mContent.Load<SoundEffect>(_file);
        }
        /// <summary>
        /// Load a Font
        /// </summary>
        /// <param name="_font">Path to Font</param>
        /// <returns>Loaded Font</returns>
        public SpriteFont LoadFont(string _font)
        {
            return mContent.Load<SpriteFont>(_font);
        }
        #endregion
    }
}
