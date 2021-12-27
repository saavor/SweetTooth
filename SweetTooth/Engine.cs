using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace SweetTooth
{
    public class Engine : Game
    {
        public string Title;

        // XNA graphics stuff
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        // Resolution
        public int WindowWidth;
        public int WindowHeight;
        public int RenderWidth;
        public int RenderHeight;
        public bool Fullscreen;

        // Clearing
        public static Color ClearColor;

        // Engine Class
        public Engine(int windowWidth, int windowHeight, bool fullscreen)
        {
            WindowWidth = windowWidth;
            WindowHeight = windowHeight;
            Fullscreen = fullscreen;
            ClearColor = Color.Black;

            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            // Graphics setup
            _graphics.SynchronizeWithVerticalRetrace = true; // VSync on
            _graphics.PreferMultiSampling = false; // Turn MSAA off
            _graphics.GraphicsProfile = GraphicsProfile.HiDef; // Set GraphicsProfile to HiDef
            _graphics.HardwareModeSwitch = false;

            if (Fullscreen)
            {
                SetFullscreen();
            }
            else
            {
                SetWindowed();
            }
            _graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            // TODO: Game quit logic

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(ClearColor);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }

        public void SetFullscreen() {
            _graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            _graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            _graphics.IsFullScreen = true;
            _graphics.ApplyChanges();
            Fullscreen = true;
        }

        public void SetWindowed() {
            _graphics.PreferredBackBufferWidth = WindowWidth;
            _graphics.PreferredBackBufferHeight = WindowHeight;
            _graphics.IsFullScreen = false;
            _graphics.ApplyChanges();
            Fullscreen = false;
        }

        public void SetBorderless() {
            _graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            _graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            Window.IsBorderless = true;
            _graphics.ApplyChanges();
            Fullscreen = false;
        }

        public void SetWindowRes(int width, int height) {
            WindowWidth = width;
            WindowHeight = height;

            // Check if game is fullscreened (it would be bad to set the res while fullscreened)
            if (!_graphics.IsFullScreen)
            {
                SetWindowed(); // Set windowed can also be used to refresh window res
            }
        }
    }
}
