using GMTB.Interfaces;
using GMTB.Managers;
using GMTB.InputSystem;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace GMTB
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Kernel : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch mSpriteBatch;

        // Managers
        IScene_Manager mSceneManager;
        IEntity_Manager mEntityManager;
        IContent_Manager mContentManager;
        IInput_Manager mInputManager;

        // String to hold the Content Root Directory
        // to be passed to the Content_Manager
        string mContentRoot;

        // Variable to hold all loaded levels
        private List<ILevel> mLevels;

        public Kernel()
        {
            graphics = new GraphicsDeviceManager(this);
            //Content.RootDirectory = "Content";

        }

        public Kernel(string content, List<ILevel> lvls) : this()
        {
            mContentRoot = content;
            mLevels = lvls;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
            mInputManager = new Input_Manager();
            mContentManager = new Content_Manager(Content, mContentRoot);
            mEntityManager = new Entity_Manager(mContentManager, mInputManager);
            mSceneManager = new Scene_Manager(mEntityManager);
            mLevels[0].Initialise(mSceneManager, mEntityManager);
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            mSpriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="_gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime _gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            mSceneManager.Update(_gameTime);
            mInputManager.GetCurrentInput();
            base.Update(_gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="_gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime _gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            mSceneManager.Draw(mSpriteBatch);
            base.Draw(_gameTime);
        }
    }
}
