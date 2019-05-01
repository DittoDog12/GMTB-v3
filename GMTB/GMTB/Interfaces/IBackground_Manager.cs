using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GMTB.Interfaces
{
    /// <summary>
    /// Interface for Background Manager
    /// </summary>
    public interface IBackground_Manager
    {
        //Texture2D Texture {set;}
        /// <summary>
        /// Main Draw Loop
        /// </summary>
        /// <param name="_spriteBatch">Reference to SpriteBatch</param>
        /// <param name="_gameTime">Reference to Current GameTime</param>
        void Draw(SpriteBatch _spriteBatch, GameTime _gameTime);
        /// <summary>
        /// Change Background
        /// </summary>
        /// <param name="_newBG">Path to new Background</param>
        void ChangeBackground(string _newBG);
        /// <summary>
        /// Change Background
        /// Double Length backgrounds
        /// </summary>
        /// <param name="_newBG1">Path to leftmost Background</param>
        /// <param name="_newBG2">Path to rightmost Background</param>
        void ChangeBackground(string _newBG1, string _newBG2);
        /// <summary>
        /// Change Bak=ckground Position
        /// </summary>
        /// <param name="_x">X Coordinate</param>
        /// <param name="_y">Y Coordinate</param>
        void ChangePosition(int _x, int _y);
        /// <summary>
        /// Blank all backgrounds
        /// </summary>
        void BlankBackgrounds();
    }
}
