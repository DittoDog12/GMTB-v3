using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace GMTB.Dialogue
{
    public interface IDialogueBox
    {
        void Draw(SpriteBatch _spriteBatch, string _line);
    }
}
