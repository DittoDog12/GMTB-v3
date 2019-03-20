using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GMTB.Interfaces
{
    public interface IScene_Manager
    {
        //IDictionary<int, IEntity> Entities { get; }
        //IDictionary<int, IEntity> SceneGraph { get; }

        void newEntity(IEntity _createdEntity, float _x, float _y);
        void newEntity(IEntity _createdEntity, Vector2 _pos);
        void Update(GameTime _gameTime);
        void Draw(SpriteBatch _spriteBatch, GameTime _gameTime);
        void Draw(SpriteBatch _spriteBatch, GameTime _gameTime, Camera2D cam, GraphicsDevice graDev);
    }
}
