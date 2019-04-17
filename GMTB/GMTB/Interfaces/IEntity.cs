using Microsoft.Xna.Framework;
using GMTB.InputSystem;

namespace GMTB.Interfaces
{
    public interface IEntity
    {
        int UID { get; }
        bool Active { get; set; }

        void setVars(int _uid, IServiceLocator _sl);      
        void Update(GameTime _gameTime);     
        void ConfigureInput();
    }
}
