using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GMTB.Interfaces
{
    public interface ISceneManager
    {
        IDictionary<int, IEntity> Entities { get; }
        IDictionary<int, IEntity> SceneGraph { get; }

        void newEntity(IEntity _createdEntity, int _x, int _y);
        void Update(GameTime _gameTime);
        void Draw(SpriteBatch _spriteBatch);
        void Draw(SpriteBatch _spriteBatch, Camera2D cam, GraphicsDevice graDev);
    }
}
