using GMTB.Abstracts;
using GMTB.CollisionSystem;
using GMTB.InputSystem;
using GMTB.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Infirmary.Characters.Player
{
    /// <summary>
    /// Player Walk State
    /// </summary>
    public class Walk : State
    {
        #region Data Members
        /// Reference to the Input Manager
        private IInput_Manager mInputManager;
        #endregion
        /// <summary>
        /// Main Constructor
        /// </summary>
        /// <param name="_mind">Reference to the Mind</param>
        public Walk(IPlayerMind _mind) : base(_mind)
        {

        }
        /// <summary>
        /// Initialize the state
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();
            mInputManager = mPMind.ServiceLocator.GetService<IInput_Manager>();
            Reactivate();
        }
        /// <summary>
        /// Main Update Loop
        /// </summary>
        /// <param name="_gameTime">Reference to the current GameTime</param>
        public override void Update(GameTime _gameTime)
        {
            
        }
        /// <summary>
        /// Reset settings when swithcing back to this state
        /// </summary>
        public override void Reactivate()
        {
            mInputManager.Sub_Space(OnSpace);
            
        }
        /// <summary>
        /// On space switch to the Jump State
        /// </summary>
        /// <param name="source">Event Source</param>
        /// <param name="args">Event Arguments</param>
        public void OnSpace(object source, InputEvent args)
        {
            if (args.currentKey == Keybindings.Jump)
            {
                mPMind.ChangeState("jump");
                mInputManager.Un_Space(OnSpace);
            }
                
        }
        /// <summary>
        /// Main Draw Loop
        /// </summary>
        /// <param name="_spriteBatch">Reference to the SpriteBatch</param>
        /// <param name="_gameTime">Reference to current GameTime</param>
        public override void Draw(SpriteBatch _spriteBatch, GameTime _gameTime)
        {
            
        }
    }
}
