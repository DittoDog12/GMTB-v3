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
    /// Interface for Scene Manager
    /// </summary>
    public interface IScene_Manager
    {
        //IDictionary<int, IEntity> Entities { get; }
        //IDictionary<int, IEntity> SceneGraph { get; }

        /// <summary>
        /// Position an entity at specifed coordinates
        /// </summary>
        /// <param name="_createdEntity">Entity to position</param>
        /// <param name="_x">X Coordinate</param>
        /// <param name="_y">Y Coordinate</param>
        void newEntity(IEntity _createdEntity, float _x, float _y);
        /// <summary>
        /// Position an entity at specifed coordinates
        /// </summary>
        /// <param name="_createdEntity">Entitiy to position</param>
        /// <param name="_pos">Vector Coordinates</param>
        void newEntity(IEntity _createdEntity, Vector2 _pos);
        /// <summary>
        /// Main Update Loop
        /// Gets all active entities from the Entity managers master list and runs their Update Methods
        /// </summary>
        /// <param name="_gameTime">Reference to the current GameTime</param>
        void Update(GameTime _gameTime);
        /// <summary>
        /// Main Draw Loop
        /// Gets all active physical entities from the Entity managers master list and run their Draw Methods
        /// </summary>
        /// <param name="_spriteBatch">Reference to the SpriteBatch</param>
        /// <param name="_gameTime">Reference to the current GameTime</param>
        void Draw(SpriteBatch _spriteBatch, GameTime _gameTime);
    }
}
