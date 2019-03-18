using Microsoft.Xna.Framework;
using GMTB.InputSystem;

namespace GMTB.Interfaces
{
    public interface IEntity
    {
        int UID { get; }
       

        void setVars(int _uid, IEntity_Manager _em);      
        void Update(GameTime _gameTime);     
        void ConfigureInput(IInput_Manager _im);
    }
}
