using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace GMTB.Interfaces
{
    /// <summary>
    /// Interface for AI Manager
    /// </summary>
    public interface IAI_Manager
    {
        /// <summary>
        /// Main Update Loop
        /// </summary>
        /// <param name="_gameTime">Reference to current GameTime</param>
        void Update(GameTime _gameTime);
    }
}
