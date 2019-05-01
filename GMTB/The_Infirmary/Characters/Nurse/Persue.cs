using GMTB.Abstracts;
using GMTB.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Infirmary.Characters.Nurse
{
    /// <summary>
    /// Nurse Persue Behaviour
    /// </summary>
    public class Persue : State
    {
        /// <summary>
        /// Main Constructor
        /// </summary>
        /// <param name="_mind">Reference to the Mind</param>
        public Persue(IAIMind _mind) : base(_mind)
        {
            mPath = new Queue<Point>();
            
        }

        /// <summary>
        /// Main Update Loop
        /// </summary>
        /// <param name="_gameTime">Reference to the current GameTime</param>
        public override void Update(GameTime _gameTime)
        {
            mMind.MySelf.Moving = true;
            mMind.MySelf.ApplyForce(PlotPath());
        }
        /// <summary>
        /// Plot a path
        /// </summary>
        /// <returns>Direction to the path</returns>
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
