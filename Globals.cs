using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlapyBird
{
    public static class Globals
    {
        public static ContentManager Content {  get; set; }

        public static SpriteBatch SpriteBatch { get; set; }

        public static GraphicsDevice Device { get; set; }

        public static float ElapsedSeconds { get; set; }

        public static void Update (GameTime gameTime)
        {
            ElapsedSeconds = (float)gameTime.ElapsedGameTime.TotalSeconds;
        }
    }
}
