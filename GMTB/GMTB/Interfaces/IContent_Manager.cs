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
    public interface IContent_Manager
    {
        Texture2D ApplyTexture(string tex);
        SoundEffect LoadSound(string _file);
    }
}
