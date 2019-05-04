using GMTB.CollisionSystem;
using GMTB.InputSystem;
using GMTB.Interfaces;
using GMTB.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
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
        /// Reference to the Scene Manager
        private IScene_Manager mSceneManager;
        //private IEntity_Manager mEntityManager;
        //private IContent_Manager mContentManager;
        /// Reference to the Service Locator
        private IServiceLocator mServiceLocator;
        /// Reference to the Input Manager
        private IInput_Manager mInputManager;
        /// Reference to the Collision Manager
        private ICollision_Manager mCollisionManager;
        /// Reference to the AI Manager
        private IAI_Manager mAIManager;
        /// Reference to the Background Manager
        private IBackground_Manager mBackgroundManager;
        /// Reference to the Menu Manager
        private IMenu_Manager mMenuManager;
        /// Reference to the Level Manager
        private ILevel_Manager mLevelManager;

        /// String to hold the Content Root Directory, to be passed to the Content_Manager
        private string mContentRoot;

        /// Variable to hold all loaded levels
        private IDictionary<string, ILevel> mLevels;

        /// variable to hold all the menus
        private IDictionary<string, IMenu> mMenus;

        /// Variable to hold the texture refresh rate
        private float mRefreshRate = 5f;
        /// Variable to hold the texture refresh timer
        private float mRefreshTimer = 0f;

        /// Hold the 2D Camera if needed
        private Camera2D mCamera;

        /// Hold an alternate quadtree size if needed
        private Point mQTreeSize;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public Kernel()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferHeight = 900;
            graphics.PreferredBackBufferWidth = 1440;
            graphics.ApplyChanges();

            Global.ScreenHeight = graphics.PreferredBackBufferHeight;
            Global.ScreenWidth = graphics.PreferredBackBufferHeight;

            //Content.RootDirectory = "Content";

        }
        /// <summary>
        /// Main Constructor
        /// </summary>
        /// <param name="content">Content Root Directory</param>
        /// <param name="lvls">Pass dictionary of all levels here</param>
        /// <param name="_menus">Pass dictionary of all menus here</param>
        public Kernel(string _content, IDictionary<string, ILevel> _lvls, IDictionary<string, IMenu> _menus) : this()
        {
            mContentRoot = _content;
            mLevels = _lvls;
            mMenus = _menus;
        }
        /// <summary>
        /// Specify alternate quadtree size
        /// </summary>
        /// <param name="content">Content Root Directory</param>
        /// <param name="lvls">Pass dictionary of all levels here</param>
        /// <param name="_menus">Pass dictionary of all menus here</param>
        /// <param name="_qtsize">Alternate Quadtree dimensions</param>
        public Kernel(string _content, IDictionary<string, ILevel> _lvls, IDictionary<string, IMenu> _menus, Point _qtsize) : this(_content, _lvls, _menus)
        {
            mQTreeSize = _qtsize;
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
            // Check if alternate Quadtree size specifed and apply, otherwise use the default viewport size
            if (mQTreeSize != null)
                mServiceLocator = new ServiceLocator(Content, mContentRoot, mLevels, mMenus, mQTreeSize);
            else
                mServiceLocator = new ServiceLocator(Content, mContentRoot, mLevels, mMenus,
                    new Point(graphics.GraphicsDevice.Viewport.Width, graphics.GraphicsDevice.Viewport.Height));

            


            // Retrive Managers required
            mSceneManager = mServiceLocator.GetService<IScene_Manager>();
            mCollisionManager = mServiceLocator.GetService<ICollision_Manager>();
            mInputManager = mServiceLocator.GetService<IInput_Manager>();
            mAIManager = mServiceLocator.GetService<IAI_Manager>();
            mMenuManager = mServiceLocator.GetService<IMenu_Manager>();
            mLevelManager = mServiceLocator.GetService<ILevel_Manager>();
            mBackgroundManager = mServiceLocator.GetService<IBackground_Manager>();

            if (mCamera != null)
            {
                mCamera.Intialize(mServiceLocator);
                mMenuManager.ConfigureCamera(mCamera);
            }

            Console.WriteLine("Max Texture Size: " + CalculateMaxTextureSize());
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
            mMenuManager.InitializeMenus();
            mMenuManager.ActivateMenu("main");
            Global.GameState = Global.availGameStates.Menu;
        }
        /// <summary>
        /// Call if 2D camera is needed
        /// </summary>
        public void Need2DCamera()
        {
            mCamera = new Camera2D(graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);
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

            mInputManager.GetCurrentInput(_gameTime);

            // TODO: Add your update logic here
            switch (Global.GameState)
            {
                case Global.availGameStates.Playing:
                    mSceneManager.Update(_gameTime);
                    mAIManager.Update(_gameTime);
                    if (mCamera != null) mCamera.Update(_gameTime);
                    mCollisionManager.CollisionDetec();
                    break;
                case Global.availGameStates.Menu:
                    mMenuManager.Update(_gameTime);
                    break;
                case Global.availGameStates.Exiting:
                    Exit();
                    break;
                case Global.availGameStates.Resuming:
                    // IsMouseVisible = false;
                    Global.GameState = Global.availGameStates.Playing;
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
            GraphicsDevice.Clear(Color.Black);
            mRefreshTimer += (float)_gameTime.ElapsedGameTime.TotalMilliseconds;

            // Check if a 2D camera exists, configure spritebatch accordingly
            if (mCamera != null)
                mSpriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend,
                null, null, null, null, mCamera.GetTransform(GraphicsDevice));
            else mSpriteBatch.Begin();

            mBackgroundManager.Draw(mSpriteBatch, _gameTime);

            if (mRefreshTimer >= mRefreshRate)
            {
                mSceneManager.Draw(mSpriteBatch, _gameTime);
                if (Global.GameState == Global.availGameStates.Menu)
                    mMenuManager.Draw(mSpriteBatch);
                // TODO: Add your drawing code here
                mRefreshTimer = 0f;
            }
            mSpriteBatch.End();
            base.Draw(_gameTime);
        }

        /// <summary>
        /// Max texture size supported by the current device.
        /// </summary>
        public int MaxTextureSize
        {
            get
            {
                if (maxTextureSize == 0)
                    maxTextureSize = CalculateMaxTextureSize();
                return maxTextureSize;
            }
        }
        private int maxTextureSize;
        private int CalculateMaxTextureSize()
        {
            var maxSize = 0;
            var i = 8;
            while (i < 20)
            {
                try
                {
                    var size = (int)Math.Pow(2, i);
                    new Texture2D(mSpriteBatch.GraphicsDevice, size, 1);
                    maxSize = size;

                    size++;
                    new Texture2D(mSpriteBatch.GraphicsDevice, size, 1);
                    maxSize = size;
                }
                catch (Exception e)
                {
                    break;
                }
                i++;
            }
            return maxSize;
        }
    }
}
