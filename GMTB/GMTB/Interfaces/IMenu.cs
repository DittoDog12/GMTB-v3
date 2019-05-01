using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMTB.Interfaces;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using GMTB.InputSystem;

namespace GMTB.Interfaces
{
    /// <summary>
    /// Interface for Menus
    /// </summary>
    public interface IMenu
    {
        /// Menu Texture/Background
        Texture2D Texture { get; }
        /// Menu Identifier
        string Name { get; }

        /// <summary>
        /// Main initialize routine
        /// </summary>
        /// <param name="_sl">Reference to Service Locator</param>
        /// <param name="_cam">Reference to 2D Camera, if needed</param>
        void Initialize(IServiceLocator _sl, Camera2D _cam);
        /// <summary>
        /// Main Update Loop
        /// </summary>
        /// <param name="_gameTime">Reference to current GameTime</param>
        void Update(GameTime _gameTime);
        /// <summary>
        /// Main Draw loop
        /// </summary>
        /// <param name="_spriteBatch">Reference to SpriteBatch</param>
        void Draw(SpriteBatch _spriteBatch);
        /// <summary>
        /// Subscribe any Input events needed
        /// </summary>
        void Subscribe();
    }
}
