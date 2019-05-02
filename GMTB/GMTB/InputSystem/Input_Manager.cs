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
    /// <summary>
    /// Mouse event mini public class
    /// </summary>
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
    /// <summary>
    /// Main input manager
    /// </summary>
    class Input_Manager : IInput_Manager
    {
        #region Data Members
        /// Previous Keyboard State
        private KeyboardState _oldKState;
        /// Previous Persistant Keyboard State
        private KeyboardState _oldPKState;
        /// Previous Gamepad State
        private GamePadState _oldGState;
        /// Previous Mouse State
        private MouseState _oldMState;
        /// Movement Key Input subscribers
        public event EventHandler<InputEvent> Movement;
        /// Space Key Input subscribers
        public event EventHandler<InputEvent> Space;
        /// Escape Key Input subscribers
        public event EventHandler<InputEvent> Esc;
        /// Use Key Input subscribers
        public event EventHandler<InputEvent> Use;
        /// Mouse Input subscribers
        public event EventHandler<MouseEvent> MouseUsers;

        /// Detection Update interval
        private float mInterval;
        /// Detection Update Timer
        private float mTimer;
        #endregion

        #region Constructor
        /// <summary>
        /// Main Constructor
        /// </summary>
        public Input_Manager()
        {
            _oldKState = Keyboard.GetState();
            _oldPKState = Keyboard.GetState();
            mTimer = 0f;
            mInterval = 100f;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Controller checking method
        /// </summary>
        /// <returns> Boolean indicating controller connected state </returns>
        public bool CheckController()
        {
            if (GamePad.GetState(PlayerIndex.One).IsConnected)
                return true;
            else
                return false;
        }
        /// <summary>
        /// Main input detection method
        /// </summary>
        public void GetCurrentInput(GameTime _gameTime)
        {
            // Check for persistant keypresses every update
            // Only if game is in playing state
            if (Global.GameState == Global.availGameStates.Playing)        
                PersistantKeyboardInput();
            // Else stop the player moving
            else if (Global.GameState == Global.availGameStates.Dialogue)
                MovementRelease(Keybindings.Released);

            // Check if a controller is connected, detect input from that if true
            if (CheckController())
                GamePadInput();

            // Only check for other input if not on cool down.
            mTimer -= _gameTime.ElapsedGameTime.Milliseconds;
            if (mTimer <= 0f)
            {
                // Get Mouse Input
                MouseInput();
                
                // else //Enable this top stop keyboard detection if controller detected
                // Get Keyboard Input
                KeyboardInput();
           }
            

        }
        /// <summary>
        /// Check for mouse button presses, and where the mouse was clicked.
        /// </summary>
        private void MouseInput()
        {
            MouseState _mouseState = Mouse.GetState();
            if (_oldMState.LeftButton == ButtonState.Pressed && _mouseState.LeftButton == ButtonState.Released)
                MouseInput(Keybindings.Click, new Vector2(_mouseState.X, _mouseState.Y));

            _oldMState = _mouseState;
        }
        /// <summary>
        /// Check for Keypresses that should be persistant, IE movement keys held down 
        /// </summary>
        private void PersistantKeyboardInput()
        {
            KeyboardState _newPKState = Keyboard.GetState();

            if (_newPKState.IsKeyDown(Keys.W))
                MovementInput(Keybindings.Up);
            else if (_newPKState.IsKeyDown(Keys.S))
                MovementInput(Keybindings.Down);

            if (_newPKState.IsKeyDown(Keys.A))
                MovementInput(Keybindings.Left);
            else if (_newPKState.IsKeyDown(Keys.D))
                MovementInput(Keybindings.Right);

            if ((_newPKState.IsKeyUp(Keys.W) && _oldPKState.IsKeyDown(Keys.W))
                || (_newPKState.IsKeyUp(Keys.S) && _oldPKState.IsKeyDown(Keys.S)))
                MovementRelease(Keybindings.Released);

            if ((_newPKState.IsKeyUp(Keys.A) && _oldPKState.IsKeyDown(Keys.A))
                || (_newPKState.IsKeyUp(Keys.D) && _oldPKState.IsKeyDown(Keys.D)))
                MovementRelease(Keybindings.Released);

            _oldPKState = _newPKState;

        }
        /// <summary>
        /// Check for all other inputs that should only trigger once.
        /// </summary>
        private void KeyboardInput()
        {

            KeyboardState _newKState = Keyboard.GetState();

            if (_oldKState.IsKeyUp(Keys.E) && _newKState.IsKeyDown(Keys.E))
                UseInput(Keybindings.Use);

            if (_oldKState.IsKeyUp(Keys.Space) && _newKState.IsKeyDown(Keys.Space))
                SpaceInput(Keybindings.Jump);

            if (_oldKState.IsKeyUp(Keys.Escape) && _newKState.IsKeyDown(Keys.Escape))
                EscapeInput(Keybindings.Pause);

            _oldKState = _newKState;
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
            else if (_newGState.ThumbSticks.Left.X > 0)
                MovementInput(Keybindings.Right);

            if (_oldGState.ThumbSticks.Left.X < 0 && _newGState.ThumbSticks.Left.X == 0
                || _oldGState.ThumbSticks.Left.X > 0 && _newGState.ThumbSticks.Left.X == 0)
                MovementRelease(Keybindings.Released);

            if (_oldGState.Buttons.X == ButtonState.Released && _newGState.Buttons.X == ButtonState.Pressed)
                UseInput(Keybindings.Use);

            if (_oldGState.Buttons.A == ButtonState.Released && _newGState.Buttons.A == ButtonState.Pressed)
                SpaceInput(Keybindings.Jump);

            if (_oldGState.Buttons.Start == ButtonState.Released && _newGState.Buttons.Start == ButtonState.Pressed)
                EscapeInput(Keybindings.Pause);

            _oldGState = _newGState;

        }
        /// <summary>
        /// Begin input cooldown
        /// IE wait for interval specifed above before allowing checking again
        /// </summary>
        private void SingleInputTriggered()
        {
            mTimer = mInterval;
        }
        #endregion

        #region EventTriggers
        /// <summary>
        /// Mouse Input Trigger
        /// </summary>
        /// <param name="key">Key clicked</param>
        /// <param name="pos">Mouse Position at moment of click</param>
        protected virtual void MouseInput(Keybindings key, Vector2 pos)
        {
            if (MouseUsers != null)
            {
                MouseEvent args = new MouseEvent(key, pos);
                MouseUsers(this, args);
            }

        }
        /// <summary>
        /// Movement Input Trigger
        /// </summary>
        /// <param name="key">Key pressed</param>
        protected virtual void MovementInput(Keybindings key)
        {
            if (Movement != null)
            {
                InputEvent args = new InputEvent(key);
                Movement(this, args);
            }
        }
        /// <summary>
        /// Movement key release trigger
        /// </summary>
        /// <param name="key">Key released</param>
        protected virtual void MovementRelease(Keybindings key)
        {
            if (Movement != null)
            {
                InputEvent args = new InputEvent(key);
                Movement(this, args);
            }
        }
        /// <summary>
        /// Space Key Input Trigger
        /// </summary>
        /// <param name="key">Key Pressed</param>
        protected virtual void SpaceInput(Keybindings key)
        {
            if (Space != null)
            {
                InputEvent args = new InputEvent(key);
                Space(this, args);
                SingleInputTriggered();
            }
        }
        /// <summary>
        /// Use Key Input Trigger
        /// </summary>
        /// <param name="key">Key Pressed</param>
        protected virtual void UseInput(Keybindings key)
        {
            if (Use != null)
            {
                InputEvent args = new InputEvent(key);
                Use(this, args);
                SingleInputTriggered();

            }
        }
        /// <summary>
        /// Escape Key Input Trigger
        /// </summary>
        /// <param name="key">Key Pressed</param>
        protected virtual void EscapeInput(Keybindings key)
        {
            if (Esc != null)
            {
                InputEvent args = new InputEvent(key);
                Esc(this, args);
                SingleInputTriggered();

            }
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
        /// <summary>
        /// Escape input unsubscriber
        /// </summary>
        /// <param name="handler"> Entity to stop receiving escapse events</param>
        public void Un_Esc(EventHandler<InputEvent> handler)
        {
            Esc -= handler;
        }
        
        #endregion
    }
}
