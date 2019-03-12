using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GMTB.Interfaces
{
    public interface IEntity
    {
        int UID { get; }
        string Texturename { get; }
        Texture2D Texture { set; }

        void setVars(int _uid);
        void setVars(string _path);
        void setPos(Vector2 _pos);
        void setDefaultPos(Vector2 _pos);
        void Update(GameTime _gameTime);
        void Draw(SpriteBatch _spriteBatch);
    }
}
