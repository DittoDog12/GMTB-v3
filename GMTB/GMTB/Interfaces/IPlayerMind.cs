using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMTB.Interfaces
{
    public interface IPlayerMind
    {
        IPlayer MySelf { get; set; }
        void Update(GameTime _gameTime);
        void ChangeState(string _newState);
        void Initialize();
    }
}
