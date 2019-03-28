using GMTB.Interfaces;
using GMTB.Managers;
using GMTB.InputSystem;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using GMTB.CollisionSystem;

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
        private IScene_Manager mSceneManager;
        //private IEntity_Manager mEntityManager;
        //private IContent_Manager mContentManager;
        private IServiceLocator mServiceLocator;
        private IInput_Manager mInputManager;
        private ICollision_Manager mCollisionManager;
        private IAI_Manager mAIManager;
        //private IBackground_Manager mBackgroundManager;
        private IMenu_Manager mMenuManager;

        // String to hold the Content Root Directory
        // to be passed to the Content_Manager
        private string mContentRoot;

        // Variable to hold all loaded levels
        private IDictionary<string, ILevel> mLevels;

        // variable to hold all the menus
        private IDictionary<string, IMenu> mMenus;

        // Variables to hold the texture refresh rate and the timer
        private float mRefreshRate = 5f;
        private float mRefreshTimer = 0f;

        public Kernel()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferHeight = 900;
            graphics.PreferredBackBufferWidth = 1440;
            graphics.ApplyChanges();

            Global.ScreenSize = new Vector2 (graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);

            //Content.RootDirectory = "Content";

        }

        public Kernel(string content, IDictionary<string, ILevel> lvls, IDictionary<string, IMenu> _menus) : this()
        {
            mContentRoot = content;
            mLevels = lvls;
            mMenus = _menus;
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
            // Create Input Manager
            //mInputManager = new Input_Manager();
            // Create Service Locator and all Managers
            mServiceLocator = new ServiceLocator(Content, mContentRoot, mLevels, mMenus, 
                new Point(graphics.GraphicsDevice.Viewport.Width, graphics.GraphicsDevice.Viewport.Height));

            // Retrive Managers required
            mSceneManager = mServiceLocator.GetService<IScene_Manager>();
            mCollisionManager = mServiceLocator.GetService<ICollision_Manager>();
            mInputManager = mServiceLocator.GetService<IInput_Manager>();
            mAIManager = mServiceLocator.GetService<IAI_Manager>();
            mMenuManager = mServiceLocator.GetService<IMenu_Manager>();

            // Create Content Manager, pass Monogame Content Manager and Path to Content Root
            //mContentManager = new Content_Manager(Content, mContentRoot);
            //mContentManager = mServiceLocator.GetService<IContent_Manager>();

            // Create Background Manager, pass Content Manager
            //mBackgroundManager = new Background_Manager(mContentManager);
            // Create Entity Manager, pass Content and Input Managers
            //mEntityManager = new Entity_Manager(mServiceLocator, mContentManager, mInputManager);
            // Create Scene Manager, pass Entity and Background Managers
            //mSceneManager = new Scene_Manager(mEntityManager, mBackgroundManager);
            // Create Collision Manager, pass Entity Manager and Screen Size variables
            //mCollisionMananger = new Collision_Manager(mEntityManager, new Point(graphics.GraphicsDevice.Viewport.Width, graphics.GraphicsDevice.Viewport.Height));
            // Create AI Manager, Pass the Entity Manager
            //mAIManager = new AI_Manager(mEntityManager);

            // Initialise first Level, pass Scene, Entity and Background Managers
            // mLevels[0].Initialise(mSceneManager, mEntityManager, mBackgroundManager);
            mLevels["L1"].Initialise(mServiceLocator);
            Global.GameState = Global.availGameStates.Playing;
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
            //if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            //    Global.GameState = Global.availGameStates.Exiting;

            mInputManager.GetCurrentInput();

            // TODO: Add your update logic here
            switch (Global.GameState)
            {
                case Global.availGameStates.Playing:
                    mSceneManager.Update(_gameTime);
                    mCollisionManager.CollisionDetec();
                    mAIManager.Update(_gameTime);
                    break;
                case Global.availGameStates.Menu:
                    mMenuManager.Update(_gameTime);
                    break;
                case Global.availGameStates.Exiting:
                    Exit();
                    break;
            }
            
            
            
            base.Update(_gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="_gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime _gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            mRefreshTimer += (float)_gameTime.ElapsedGameTime.TotalMilliseconds;

            if (mRefreshTimer >= mRefreshRate)
            {
                switch (Global.GameState)
                {
                    case Global.availGameStates.Playing:
                        mSceneManager.Draw(mSpriteBatch, _gameTime);
                        break;
                    case Global.availGameStates.Menu:
                        mMenuManager.Draw(mSpriteBatch);
                        break;
                }
                // TODO: Add your drawing code here
                
                mRefreshTimer = 0f;
            }
      
            base.Draw(_gameTime);
        }
    }
}
