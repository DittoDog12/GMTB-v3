using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMTB.Interfaces
{
    /// <summary>
    /// Interface for Physical Interfaces, anything with a physical presence in thw world impliments this interface
    /// </summary>
    public interface IPhysicalEntity
    {
        /// Texture path
        string Texturename { get; }
        /// Current Texture
        Texture2D Texture { get; set; }
        /// Current Texture Height
        int CurrentTextureHeight { get; }
        /// Current Texture Width
        int CurrentTextureWidth { get; }
        /// Current Position
        Vector2 Position { get; }
        /// Current Acceleration
        Vector2 Acceleration { set; }


        /// <summary>
        /// Set core variables
        /// </summary>
        /// <param name="_path">Path to texture</param>
        /// <param name="_cm">Reference to Content manager</param>
        void setVars(string _path, IContent_Manager _cm);
        /// <summary>
        /// Override current Position
        /// </summary>
        /// <param name="_pos">Position to set object to</param>
        void setPos(Vector2 _pos);
        /// <summary>
        /// Specify default position
        /// </summary>
        /// <param name="_pos">Posisiton to set as default</param>
        void setDefaultPos(Vector2 _pos);
        /// <summary>
        /// Main Draw loop
        /// </summary>
        /// <param name="_spriteBatch">Reference to the SpriteBatch</param>
        /// <param name="_gameTime">Reference to current GameTime</param>
        void Draw(SpriteBatch _spriteBatch, GameTime _gameTime);
        /// <summary>
        /// Main Update Loop
        /// </summary>
        /// <param name="_gameTime">Reference to current GameTime</param>
        void Update(GameTime _gameTime);
        /// <summary>
        /// Apply a force to the object
        /// </summary>
        /// <param name="force">Force to Apply</param>
        void ApplyForce(Vector2 force);
    }
}
