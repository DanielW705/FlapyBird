using FlapyBird.Cameras;
using FlapyBird.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using FlapyBird.Globals;

namespace FlapyBird
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private SpriteFont _font;

        private Player Player;

        private Background Background;

        private Camera Camera;

        private Pipes Pipe;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            Global.Content = Content;
            Global.Device = GraphicsDevice;

            _graphics.PreferredBackBufferWidth = 400;
            _graphics.PreferredBackBufferHeight = 500;

            _graphics.ApplyChanges();

            float speed = 6.0f;

            Camera = new Camera(GraphicsDevice.Viewport, speed);

            Background = new Background(Content.Load<Texture2D>("background"), Vector2.Zero, Camera.GetViewMatrix());

            Player = new Player(Content.Load<Texture2D>("flappy"), new Vector2(0, 0), speed);

            Pipe = new Pipes();

            _font = Content.Load<SpriteFont>("Fonts/Font");

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            Global.SpriteBatch = _spriteBatch;

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            //// TODO: Add your update logic here
           if(Pipe.Upper_Bounds.Intersects(Player.Bounds) || Pipe.Lower_Bounds.Intersects(Player.Bounds))
                Player.HasDied = true;
            
            Global.Update(gameTime);

            Camera.Update(Player.Position, gameTime);

            Player.Update(gameTime);

            Pipe.Update(gameTime);




            //Background.UpdateTransform(Player.Position.X);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            if (Player.HasDied)
            {
                _spriteBatch.Begin();
                string message = "Presione espacio para continuar";
                _spriteBatch.DrawString(_font, message, new Vector2(_graphics.PreferredBackBufferWidth / 2 - message.Length, _graphics.PreferredBackBufferHeight / 2), Color.Black);
                _spriteBatch.End();
            }
            else
            {
                Background.Draw();
                Player.Draw();
                Pipe.Draw();
            }
            // TODO: Add your drawing code here
            base.Draw(gameTime);
        }
    }
}