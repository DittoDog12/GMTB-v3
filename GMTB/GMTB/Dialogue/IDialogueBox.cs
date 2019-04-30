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
        /// <summary>
        /// Main Draw Loop
        /// </summary>
        /// <param name="_spriteBatch">Reference to Main SpriteBatch</param>
        /// <param name="_line">Text line to render</param>
        void Draw(SpriteBatch _spriteBatch, string _line);
    }
}
