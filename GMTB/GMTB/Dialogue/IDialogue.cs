using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMTB.Dialogue
{
    /// <summary>
    /// Dialogue Display System
    /// Entities with Dialogue will create a displayer and pass their lines into it
    /// Displayer will then create a renderer box and pass the lines to that when needed
    /// </summary>
    public interface IDialogue
    {
        /// <summary>
        /// Draw Text on screen
        /// </summary>
        /// <param name="_spiteBatch">Reference to main SpriteBatch</param>
        /// <param name="_gameTime">Reference to current GameTime</param>
        void Draw(SpriteBatch _spiteBatch, GameTime _gameTime);
        /// <summary>
        /// Begins dialogue routine
        /// </summary>
        void Begin();
    }
}
