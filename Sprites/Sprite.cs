using FlapyBird.Globals;
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
        public Color Color = Color.White;

        public float Speed = 0f;

        public bool IsRemoved = false;

        protected Texture2D Texture;

        public Vector2 Position;

        public Rectangle Bounds
        {
            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y, Texture.Width, Texture.Height);
            }
        }


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
            Global.SpriteBatch.Begin();
            Global.SpriteBatch.Draw(Texture, Position, Color.White);
            Global.SpriteBatch.End();
        }
    }
}
