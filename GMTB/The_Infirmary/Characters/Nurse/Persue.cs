using GMTB.Abstracts;
using GMTB.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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
        ///
        private float mPersueDistance = 150f;
        /// <summary>
        /// Main Constructor
        /// </summary>
        /// <param name="_mind">Reference to the Mind</param>
        public Persue(IAIMind _mind) : base(_mind)
        {
            mPath = new Queue<Point>();

        }
        /// <summary>
        /// Main Draw Loop
        /// </summary>
        /// <param name="_spriteBatch">Reference to the SpriteBatch</param>
        /// <param name="_gameTime">Reference to current GameTime</param>
        public override void Draw(SpriteBatch _spriteBatch, GameTime _gameTime)
        {

        }

        /// <summary>
        /// Main Update Loop
        /// </summary>
        /// <param name="_gameTime">Reference to the current GameTime</param>
        public override void Update(GameTime _gameTime)
        {
            mMind.MySelf.Moving = true;
            mMind.MySelf.ApplyForce(PlotPath());

            // If player too far away, give up
            if (mMind.MySelf.Target.Position.X - mMind.MySelf.Position.X > mPersueDistance || mMind.MySelf.Target.Position.X - mMind.MySelf.Position.X < -mPersueDistance)
                mMind.ChangeState("idle");
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
