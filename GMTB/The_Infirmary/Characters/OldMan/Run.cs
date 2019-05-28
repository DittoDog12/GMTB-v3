using GMTB.Abstracts;
using GMTB.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Infirmary.Characters.OldMan
{
    class Run : State
    {
        private IPhysicalEntity mNurse;
        private int mJumpActivation = 125;
        private float mSpeed = 7f;

        public Run(IAIMind _mind) : base(_mind)
        {
            
        }

        public override void Draw(SpriteBatch _spriteBatch, GameTime _gameTime)
        {
            
        }
        public override void Reactivate()
        {
            base.Reactivate();
            mMind.MySelf.Texturename = "Characters/OldMan/walkR";
            // Find the nurse object
            foreach (KeyValuePair<int, IEntity> _keyPair in mMind.MySelf.ServiceLocator.GetService<IEntity_Manager>().AllEntities)
                if (_keyPair.Value.Name == "nurse")
                    mNurse = _keyPair.Value as IPhysicalEntity;
        }
        public override void Update(GameTime _gameTime)
        {
            mMind.MySelf.Moving = true;
            mMind.MySelf.ApplyForce(PlotPath());

            // If Close to Nurse then Jump, only if distance is positive, if negative then assume Old Man has already jumped over the nurse
            if (mNurse.Position.X - mMind.MySelf.Position.X < mJumpActivation && mNurse.Position.X - mMind.MySelf.Position.X > 0)
                mMind.ChangeState("yeet");

            // If way off screen, despawn
            if (mMind.MySelf.Position.X > 2000)
            {
                var asInterface = mMind.MySelf as IEntity;
                mMind.MySelf.ServiceLocator.GetService<IEntity_Manager>().DestroyEntity(asInterface.UID);

            }
        }
        /// <summary>
        /// Plot a path
        /// </summary>
        /// <returns>Direction to the path</returns>
        private Vector2 PlotPath()
        {
            Vector2 _rtnval;

            // Calcualte the vector to get to the current destination
            _rtnval = new Vector2(1000, mMind.MySelf.Position.Y) - mMind.MySelf.Position;
            _rtnval.Normalize();

            return _rtnval * mSpeed;
        }
    }
}
