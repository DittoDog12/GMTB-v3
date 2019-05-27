using GMTB.Abstracts;
using GMTB.Dialogue;
using GMTB.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMTB;
using Microsoft.Xna.Framework.Graphics;

namespace The_Infirmary.Characters.OldMan
{
    /// <summary>
    /// Old Man Talking Behaviour
    /// </summary>
    public class Talk : State, ISpeaker
    {
        /// Reference to this behaviours dialouge displayer
        private IDialogue mDialogue;

        /// <summary>
        /// Main Constructor
        /// </summary>
        /// <param name="_mind">Reference to the Mind</param>
        public Talk(IAIMind _mind): base(_mind)
        {
            
        }
        public override void Initialize()
        {
            base.Initialize();
            string[] _lines = File.ReadAllLines(Environment.CurrentDirectory + "/Content/Dialogue/OldMan.txt");
            mDialogue = new DialogueDisplay(mMind.MySelf.ServiceLocator, _lines, "Characters/OldMan/fullart", "Characters/Player/fullart", this as ISpeaker);
        }
        /// <summary>
        /// Allows the dialogue system to inform the original behaviour state that the dialogue has finsihed
        /// </summary>
        public void DialougeComplete()
        {
            ChangeState("yeet");
            Global.GameState = Global.availGameStates.Playing;
        }
        /// <summary>
        /// Reactivate the Behaviour
        /// </summary>
        public override void Reactivate()
        {
            base.Reactivate();
            mDialogue.Begin();
            Global.GameState = Global.availGameStates.Dialogue;
        }
        /// <summary>
        /// Main update Loop
        /// </summary>
        /// <param name="_gameTime">Reference to the current GameTime</param>
        public override void Update(GameTime _gameTime)
        {
            
        }
        public override void Draw(SpriteBatch _spriteBatch, GameTime _gameTime)
        {
            mDialogue.Draw(_spriteBatch, _gameTime);
        }
    }
}
