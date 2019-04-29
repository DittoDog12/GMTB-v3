using Microsoft.Xna.Framework;
using GMTB.InputSystem;

namespace GMTB.Interfaces
{
    public interface IEntity
    {
        int UID { get; }

        void setVars(int _uid, IServiceLocator _sl);      
        void Update(GameTime _gameTime);     
        void ConfigureInput();
        void Suspend();
        void Resume();
        bool GetState();
    }
}
