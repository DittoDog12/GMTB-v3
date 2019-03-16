using Microsoft.Xna.Framework;
using GMTB.InputSystem;

namespace GMTB.Interfaces
{
    public interface IEntity
    {
        int UID { get; }
       

        void setVars(int _uid);      
        void Update(GameTime _gameTime);     
        void ConfigureInput(IInput_Manager _im);
    }
}
