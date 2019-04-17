using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GMTB.Interfaces
{
    public interface IBackground_Manager
    {
        Texture2D Texture {set;}
        void Draw(SpriteBatch _spriteBatch, GameTime _gameTime);
        void ChangeBackground(string _newBG);
        void ChangeBackground(string _newBG1, string _newBG2);
        void ChangePosition(int _x, int _y);
    }
}
