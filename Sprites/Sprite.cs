using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlapyBird.Sprites
{
    public class Sprite
    {
        protected KeyboardState CurrentKey;

        protected KeyboardState PreviousKey;

        public Color Color = Color.White;

        public float Speed = 0f;

        public bool IsRemoved = false;

        protected Texture2D Texture;

        public InputKeyEventArgs InputKey;

        public Rectangle Bounds
        {
            get
            {
                return new Rectangle(0, 0, Texture.Width, Texture.Height);
            }
        }

        public Vector2 Position;

        public Sprite(Texture2D texture, Vector2 position)
        {
            this.Texture = texture;
            this.Position = position;
        }
        public virtual void Update(GameTime gameTime)
        {

        }
        public virtual void Draw()
        {
            Globals.SpriteBatch.Begin();
            Globals.SpriteBatch.Draw(Texture, Position, Bounds, Color.White);
            Globals.SpriteBatch.End();
        }
    }
}
