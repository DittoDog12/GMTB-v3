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
    /// Interface for the Player mind
    /// </summary>
    public interface IPlayerMind
    {
        /// Reference to the Players Self
        IPlayer MySelf { get; set; }
        /// <summary>
        /// Main Update Loop
        /// </summary>
        /// <param name="_gameTime">Reference to the current GameTime</param>
        void Update(GameTime _gameTime);
        /// <summary>
        /// Change the state
        /// </summary>
        /// <param name="_newState">New state to specify</param>
        void ChangeState(string _newState);
        /// <summary>
        /// Main Initialize routine
        /// </summary>
        void Initialize();
    }
}
