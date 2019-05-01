using GMTB.Abstracts;
using GMTB.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Infirmary.Characters.Matron
{
    /// <summary>
    /// Matron Persue state
    /// </summary>
    public class Persue : State
    {
        /// <summary>
        /// Main Constructor
        /// </summary>
        /// <param name="_mind">Reference to the mind</param>
        public Persue(IAIMind _mind) : base(_mind)
        {
        }
        /// <summary>
        /// Main Update loop
        /// </summary>
        /// <param name="_gameTime">Reference to the current GameTime</param>
        public override void Update(GameTime _gameTime)
        {
            
        }
    }
}
