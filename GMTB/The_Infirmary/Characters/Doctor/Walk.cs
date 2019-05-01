using GMTB.Abstracts;
using GMTB.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Infirmary.Characters.Doctor
{
    /// <summary>
    /// Doctor Walk Behaviour
    /// </summary>
    public class Walk : State
    {
        /// <summary>
        /// Main Constructor
        /// </summary>
        /// <param name="_mind">Reference to the Mind</param>
        public Walk(IAIMind _mind) : base(_mind)
        {

        }
        /// <summary>
        /// Main Update Loop
        /// </summary>
        /// <param name="_gameTime">Reference to the GameTime</param>
        public override void Update(GameTime _gameTime)
        {
            mMind.MySelf.Moving = true;
            mMind.MySelf.ApplyForce(PlotPath());
        }
        /// <summary>
        /// Path plotting
        /// </summary>
        /// <returns>Direction to the destination</returns>
        private Vector2 PlotPath()
        {
            Vector2 _rtnval;

            // Calcualte the vector to get to the current destination
            _rtnval = mMind.MySelf.Target.Position - mMind.MySelf.Position;
            _rtnval.Normalize();

            return _rtnval;
        }
    }
}
