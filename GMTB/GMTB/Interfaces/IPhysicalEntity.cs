using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GMTB.Interfaces
{
    public interface IPhysicalEntity
    {
        string Texturename { get; }
        Texture2D Texture { set; }

        void setVars(string _path);
        void setPos(Vector2 _pos);
        void setDefaultPos(Vector2 _pos);
        void Draw(SpriteBatch _spriteBatch);
    }
}
