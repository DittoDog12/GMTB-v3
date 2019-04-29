using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMTB.Managers;
using Microsoft.Xna.Framework;

namespace GMTB.InputSystem
{
    #region Keybindings
    /// <summary>
    /// List of available actions
    /// </summary>
    public enum Keybindings
    {
        Up,
        Down,
        Left,
        Right,
        Use,
        Jump,
        Pause,
        Released,
        Click,
        AltClick
    }
    #endregion

    public interface IInput_Manager
    {
        /// <summary>
        /// Mouse Event Subscriber
        /// </summary>
        /// <param name="handler"> Entity to receive Mouse Events </param>
        void Sub_Mouse(EventHandler<MouseEvent> handler);
        /// <summary>
        /// Mouse Event unsubscriber
        /// </summary>
        /// <param name="handler"> Entity to stop receiving Mouse events </param>
        void Un_Mouse(EventHandler<MouseEvent> handler);
        /// <summary>
        /// Main Input checking routine
        /// </summary>
        void GetCurrentInput(GameTime _gameTime);
        /// <summary>
        /// Movement input subscriber
        /// </summary>
        /// <param name="handler"> Entity to receive Movement events</param>
        void Sub_Move(EventHandler<InputEvent> handler);
        /// <summary>
        /// Movement input unsubscriber
        /// </summary>
        /// <param name="handler"> Entity to stop receving Movement events</param>
        void Un_Move(EventHandler<InputEvent> handler);
        /// <summary>
        /// Space input subscriber
        /// </summary>
        /// <param name="handler"> Entity to receive jump events</param>
        void Sub_Space(EventHandler<InputEvent> handler);
        /// <summary>
        /// Space input unsubscriber
        /// </summary>
        /// <param name="handler"> Entity to stop receiving jump events</param>
        void Un_Space(EventHandler<InputEvent> handler);
        /// <summary>
        /// Use input subscriber
        /// </summary>
        /// <param name="handler"> Entity to receive use key events</param>
        void Sub_Use(EventHandler<InputEvent> handler);
        /// <summary>
        /// Use input unsubscriber
        /// </summary>
        /// <param name="handler"> Entity to stop receiving use key events</param>
        void Un_Use(EventHandler<InputEvent> handler);
        /// <summary>
        /// Escape input subscriber
        /// </summary>
        /// <param name="handler"> Entity to receive escape events</param>
        void Sub_Esc(EventHandler<InputEvent> handler);
        /// <summary>
        /// Escape input unsubscriber
        /// </summary>
        /// <param name="handler"> Entity to stop receiving escapse events</param>
        void Un_Esc(EventHandler<InputEvent> handler);

    }
}
