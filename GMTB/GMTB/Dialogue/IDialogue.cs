using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GMTB.Dialogue
{
    public interface IDialogue
    {
        void Draw(SpriteBatch _spiteBatch, GameTime _gameTime);
        void Begin();
    }
}
