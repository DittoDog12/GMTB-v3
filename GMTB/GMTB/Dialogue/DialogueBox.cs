using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using GMTB.Interfaces;

namespace GMTB.Dialogue
{
    /// <summary>
    /// Rendering box for text
    /// </summary>
    public class DialogueBox : IDialogueBox
    {
        #region Data Members
        /// Reference to Content Manager
        private IContent_Manager mContentManager;
        /// Font Reference
        private SpriteFont mFont;
        #endregion

        #region Constructor
        /// <summary>
        /// Main Constructor
        /// </summary>
        /// <param name="_sl">Reference to Service Locator</param>
        /// <param name="_pos">Position to render text</param>
        public DialogueBox(IServiceLocator _sl)
        {
            mContentManager = _sl.GetService<IContent_Manager>();
            mFont = mContentManager.LoadFont("Text");
        }
        #endregion

        #region Methods
        /// <summary>
        /// Main Draw Loop
        /// </summary>
        /// <param name="_spriteBatch">Reference to Main SpriteBatch</param>
        /// <param name="_line">Text line to render</param>
        public void Draw(SpriteBatch _spriteBatch, string _line, Vector2 _pos)
        {
            _spriteBatch.DrawString(mFont, _line, _pos, Color.White);
        }
        #endregion
    }
}
