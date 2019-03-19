using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace GMTB
{
    /// <summary>
    /// Holds all Globally available variables
    /// </summary>
    public static class Global
    {
        /// <summary>
        /// List of available Game States
        /// </summary>
        public enum availGameStates
        {
            Menu,
            Playing,
            GameOver,
            Dialogue,
            Loading,
            Exiting,
            Paused,
            Resuming
        }
        /// <summary>
        /// Static availGameStates to hold the current GameState
        /// </summary>
        public static availGameStates GameState { get; set; }

        public static Vector2 ScreenSize { get; set; }
    }
}
