using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace GMTB.Interfaces
{
    public interface IPlayer
    {
        Vector2 GetPos();
        Texture2D Texture { set; }
    }
}
