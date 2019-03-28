using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMTB.Interfaces;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace GMTB.Interfaces
{
    public interface IMenu
    {
        Texture2D Texture { get; }

        void Update(GameTime _gameTime);
        void Draw(SpriteBatch _spriteBatch);
    }
}
