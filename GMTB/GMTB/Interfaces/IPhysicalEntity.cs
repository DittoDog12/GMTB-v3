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
        Texture2D Texture { get; set; }
        Vector2 Position { get; }
        Vector2 Acceleration { set; }

        void setVars(string _path, IContent_Manager _cm);
        void setPos(Vector2 _pos);
        void setDefaultPos(Vector2 _pos);
        void Draw(SpriteBatch _spriteBatch);
        void Update(GameTime _gameTime);
        void ApplyForce(Vector2 force);
    }
}
