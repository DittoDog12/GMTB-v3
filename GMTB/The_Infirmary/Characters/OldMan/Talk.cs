using GMTB.Abstracts;
using GMTB.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Infirmary.Characters.OldMan
{
    /// <summary>
    /// Old Man Talking Behaviour
    /// </summary>
    public class Talk : State
    {
        /// <summary>
        /// Main Constructor
        /// </summary>
        /// <param name="_mind">Reference to the Mind</param>
        public Talk(IAIMind _mind): base(_mind)
        {

        }
        /// <summary>
        /// Main update Loop
        /// </summary>
        /// <param name="_gameTime">Reference to the current GameTime</param>
        public override void Update(GameTime _gameTime)
        {
            
        }
    }
}
