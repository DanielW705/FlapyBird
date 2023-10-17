using FlapyBird.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FlapyBird
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Player Player;

        private Background Background;

        private Camera Camera;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            Globals.Content = Content;
            Globals.Device = GraphicsDevice;

            _graphics.PreferredBackBufferWidth = 400;
            _graphics.PreferredBackBufferHeight = 500;

            _graphics.ApplyChanges();

            float speed = 6.0f;

            Camera = new Camera(GraphicsDevice.Viewport, speed);

            Player = new Player(Content.Load<Texture2D>("flappy"), new Vector2(0, 0), speed);


            Background = new Background(Content.Load<Texture2D>("background"), Vector2.Zero, Camera.GetViewMatrix());
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            Globals.SpriteBatch = _spriteBatch;

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            Globals.Update(gameTime);

            Camera.Update(Player.Position, gameTime);

            Player.Update(gameTime);

            //Background.UpdateTransform(Player.Position.X);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            Background.Draw();
            Player.Draw();
            base.Draw(gameTime);
        }
    }
}