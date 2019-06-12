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
        private float mPersueDistance = 160f;
        /// <summary>
        /// Main Constructor
        /// </summary>
        /// <param name="_mind">Reference to the Mind</param>
        public Persue(IAIMind _mind) : base(_mind)
        {
            mPath = new Queue<Point>();

        }
        public override void Reactivate()
        {
            base.Reactivate();
            IAnimation _animation = mMind.MySelf as IAnimation;
            _animation.Frames = 8;
            _animation.Columns = 8;
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
            if (mMind.MySelf.CurrentDirection == GMTB.Entities.FacingDirection.Right)
                mMind.MySelf.Texturename = "Characters/Nurse1/walkR";
            else if (mMind.MySelf.CurrentDirection == GMTB.Entities.FacingDirection.Left)
                mMind.MySelf.Texturename = "Characters/Nurse1/walkL";

            mMind.MySelf.Moving = true;
            mMind.MySelf.ApplyForce(PlotPath());

            // If player too far away, give up
            Vector2 v1 = new Vector2(mMind.Target.Position.X, 0);
            Vector2 v2 = new Vector2(mMind.MySelf.Position.X, 0);
            float _distance = Vector2.Distance(v1, v2);
            if (_distance > mPersueDistance)
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
