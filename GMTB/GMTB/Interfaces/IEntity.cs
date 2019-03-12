using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using GMTB.InputSystem;

namespace GMTB.Interfaces
{
    public interface IEntity
    {
        int UID { get; }
        string Texturename { get; }
        Texture2D Texture { set; }

        void setVars(int _uid, IContent_Manager cm);
        void setVars(string _path);
        void setPos(Vector2 _pos);
        void setDefaultPos(Vector2 _pos);
        void Update(GameTime _gameTime);
        void Draw(SpriteBatch _spriteBatch);
        void ConfigureInput(IInput_Manager im);
    }
}
