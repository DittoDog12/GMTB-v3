using GMTB.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;

namespace GMTB.InputSystem
{
    #region Input Event
    /// <summary>
    /// Input Event mini public class
    /// </summary> 
    public class InputEvent : EventArgs
    {
        public Keybindings currentKey;

        public InputEvent(Keybindings _key)
        {
            currentKey = _key;
        }
    }
    public class MouseEvent : EventArgs
    {
        public Keybindings currentKey;
        public Vector2 currentPos;

        public MouseEvent(Keybindings _key, Vector2 _pos)
        {
            currentKey = _key;
            currentPos = _pos;
        }
    }
    #endregion

    class Input_Manager : IInput_Manager
    {
        #region Data Members
        private KeyboardState _oldState;
        private GamePadState _oldGState;
        private MouseState _oldMState;
        public event EventHandler<InputEvent> Movement;
        public event EventHandler<InputEvent> Space;
        public event EventHandler<InputEvent> Esc;
        public event EventHandler<InputEvent> Use;
        public event EventHandler<MouseEvent> MouseUsers;
        #endregion

        #region Constructor
        public Input_Manager()
        {
            _oldState = Keyboard.GetState();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Controller checking method
        /// </summary>
        /// <returns> Boolean indicating controller connected state </returns>
        private bool CheckController()
        {
            if (GamePad.GetState(PlayerIndex.One).IsConnected)
                return true;
            else
                return false;
        }
        /// <summary>
        /// Main input detection method
        /// </summary>
        public void GetCurrentInput()
        {
            // Get Mouse Input
            MouseInput();
            // Check if a controller is connected, detect input from that if true
            if (CheckController())
                GamePadInput();
            // else //Enable this top stop keyboard detection if controller detected
            // Get Keyboard Input
            KeyboardInput();
        }
        private void MouseInput()
        {
            MouseState _mouseState = Mouse.GetState();
            if (_oldMState.LeftButton == ButtonState.Pressed && _mouseState.LeftButton == ButtonState.Released)
                MouseInput(Keybindings.Click, new Vector2(_mouseState.X, _mouseState.Y));

            _oldMState = _mouseState;
        }
        private void KeyboardInput()
        {
            KeyboardState _newState = Keyboard.GetState();

            if (_newState.IsKeyDown(Keys.W))
                MovementInput(Keybindings.Up);
            else if (_newState.IsKeyDown(Keys.S))
                MovementInput(Keybindings.Down);

            if ((_newState.IsKeyUp(Keys.W) && _oldState.IsKeyDown(Keys.W))
                || (_newState.IsKeyUp(Keys.S) && _oldState.IsKeyDown(Keys.S)))
                MovementRelease(Keybindings.Released);

            if (_newState.IsKeyDown(Keys.A))
                MovementInput(Keybindings.Left);
            else if (_newState.IsKeyDown(Keys.D))
                MovementInput(Keybindings.Right);

            if ((_newState.IsKeyUp(Keys.A) && _oldState.IsKeyDown(Keys.A))
                || (_newState.IsKeyUp(Keys.D) && _oldState.IsKeyDown(Keys.D)))
                MovementRelease(Keybindings.Released);

            if (_oldState.IsKeyUp(Keys.E) && _newState.IsKeyDown(Keys.E))
                UseInput(Keybindings.Use);

            if (_oldState.IsKeyUp(Keys.Space) && _newState.IsKeyDown(Keys.Space))
                SpaceInput(Keybindings.Jump);



            _oldState = _newState;
        }
        /// <summary>
        /// Second method to check for gamepad input
        /// </summary>
        private void GamePadInput()
        {
            GamePadState _newGState = GamePad.GetState(PlayerIndex.One);

            if (_newGState.ThumbSticks.Left.Y > 0)
                MovementInput(Keybindings.Up);
            else if (_newGState.ThumbSticks.Left.Y < 0)
                MovementInput(Keybindings.Down);

            if (_newGState.ThumbSticks.Left.X < 0)
                MovementInput(Keybindings.Left);
            else if (_newGState.ThumbSticks.Left.X < 0)
                MovementInput(Keybindings.Right);

            if (_oldGState.Buttons.X == ButtonState.Released && _newGState.Buttons.X == ButtonState.Pressed)
                UseInput(Keybindings.Use);

            if (_oldGState.Buttons.A == ButtonState.Released && _newGState.Buttons.A == ButtonState.Pressed)
                SpaceInput(Keybindings.Jump);

            _oldGState = _newGState;

        }
        
        #endregion

        #region EventTriggers
        protected virtual void MouseInput(Keybindings key, Vector2 pos)
        {
            MouseEvent args = new MouseEvent(key, pos);
            MouseUsers(this, args);
        }
        protected virtual void MovementInput(Keybindings key)
        {
            InputEvent args = new InputEvent(key);
            Movement(this, args);
        }
        protected virtual void MovementRelease(Keybindings key)
        {
            InputEvent args = new InputEvent(key);
            Movement(this, args);
        }
        protected virtual void SpaceInput(Keybindings key)
        {
            InputEvent args = new InputEvent(key);
            Space(this, args);
        }
        protected virtual void UseInput(Keybindings key)
        {
            InputEvent args = new InputEvent(key);
            Use(this, args);
        }
        protected virtual void EscapeInput(Keybindings key)
        {
            InputEvent args = new InputEvent(key);
            Esc(this, args);
        }
        #endregion

        #region Subscribers
        /// <summary>
        /// Mouse Event Subscriber
        /// </summary>
        /// <param name="handler"> Entity to receive Mouse Events </param>
        public void Sub_Mouse(EventHandler<MouseEvent> handler)
        {
            MouseUsers += handler;
        }
        /// <summary>
        /// Mouse Event unsubscriber
        /// </summary>
        /// <param name="handler"> Entity to stop receiving Mouse events </param>
        public void Un_Mouse(EventHandler<MouseEvent> handler)
        {
            MouseUsers -= handler;
        }
        /// <summary>
        /// Movement input subscriber
        /// </summary>
        /// <param name="handler"> Entity to receive Movement events</param>
        public void Sub_Move(EventHandler<InputEvent> handler)
        {
            Movement += handler;
        }
        /// <summary>
        /// Movement input unsubscriber
        /// </summary>
        /// <param name="handler"> Entity to stop receving Movement events</param>
        public void Un_Move(EventHandler<InputEvent> handler)
        {
            Movement -= handler;
        }
        /// <summary>
        /// Space input subscriber
        /// </summary>
        /// <param name="handler"> Entity to receive jump events</param>
        public void Sub_Space(EventHandler<InputEvent> handler)
        {
            Space += handler;
        }
        /// <summary>
        /// Space input unsubscriber
        /// </summary>
        /// <param name="handler"> Entity to stop receiving jump events</param>
        public void Un_Space(EventHandler<InputEvent> handler)
        {
            Space -= handler;
        }
        /// <summary>
        /// Use input subscriber
        /// </summary>
        /// <param name="handler"> Entity to receive use key events</param>
        public void Sub_Use(EventHandler<InputEvent> handler)
        {
            Use += handler;
        }
        /// <summary>
        /// Use input unsubscriber
        /// </summary>
        /// <param name="handler"> Entity to stop receiving use key events</param>
        public void Un_Use(EventHandler<InputEvent> handler)
        {
            Use -= handler;
        }
        /// <summary>
        /// Escape input subscriber
        /// </summary>
        /// <param name="handler"> Entity to receive escape events</param>
        public void Sub_Esc(EventHandler<InputEvent> handler)
        {
            Esc += handler;
        }
        public void Un_Esc(EventHandler<InputEvent> handler)
        {
            Esc -= handler;
        }
        /// <summary>
        /// Escape input unsubscriber
        /// </summary>
        /// <param name="handler"> Entity to stop receiving escapse events</param>
        #endregion
    }
}
