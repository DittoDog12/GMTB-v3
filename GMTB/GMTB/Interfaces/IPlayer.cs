using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace GMTB.Interfaces
{
    /// <summary>
    /// Interface for the player
    /// </summary>
    public interface IPlayer
    {
        /// <summary>
        /// Get current position
        /// </summary>
        /// <returns>Current Vector Position</returns>
        Vector2 GetPos();
        /// Set Current Texture
        Texture2D Texture { set; }
    }
}
