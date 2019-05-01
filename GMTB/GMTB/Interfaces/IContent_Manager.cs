using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;

namespace GMTB.Interfaces
{
    /// <summary>
    /// Interface for Content Manager
    /// </summary>
    public interface IContent_Manager
    {
        /// <summary>
        /// Load a texture
        /// </summary>
        /// <param name="tex">Path to texture</param>
        /// <returns>Loaded texture</returns>
        Texture2D ApplyTexture(string tex);
        /// <summary>
        /// Load a sound
        /// </summary>
        /// <param name="_file">Path to Sound</param>
        /// <returns>Loaded Sound</returns>
        SoundEffect LoadSound(string _file);
        /// <summary>
        /// Load a Font
        /// </summary>
        /// <param name="_font">Path to Font</param>
        /// <returns>Loaded Font</returns>
        SpriteFont LoadFont(string _font);
    }
}
