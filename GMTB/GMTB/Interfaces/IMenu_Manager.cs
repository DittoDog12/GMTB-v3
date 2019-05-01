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
    /// Interface for Menu Manager
    /// </summary>
    public interface IMenu_Manager
    {
        /// <summary>
        /// Configure 2D camera Position if needed
        /// </summary>
        /// <param name="_cam">Reference to the 2D Camera</param>
        void ConfigureCamera(Camera2D _cam);
        /// <summary>
        /// Main Update Loop
        /// </summary>
        /// <param name="_gameTime">Reference to current GameTime</param>
        void Update(GameTime _gameTime);
        /// <summary>
        /// Main Draw Loop
        /// </summary>
        /// <param name="_spriteBatch">Reference to the SpriteBatch</param>
        void Draw(SpriteBatch _spriteBatch);
        /// <summary>
        /// Activate a specifed Menu
        /// </summary>
        /// <param name="_targetMenu">Menu to switch to</param>
        void ActivateMenu(string _targetMenu);
        /// <summary>
        /// Initialize all menus
        /// </summary>
        void InitializeMenus();
    }
}
