using FlapyBird.Globals;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace FlapyBird.Sprites
{
    public class Pipes
    {
        private Texture2D upper_pipe;

        private Texture2D lower_pipe;

        public Vector2 upper_pipe_pos;

        public Vector2 lower_pipe_pos;


        public float Speed = 1.0f;

        public Rectangle Upper_Bounds
        {
            get
            {
                return new Rectangle((int)upper_pipe_pos.X, (int)upper_pipe_pos.Y, upper_pipe.Width, upper_pipe.Height);
            }
        }
        public Rectangle Lower_Bounds
        {
            get
            {
                return new Rectangle((int)upper_pipe_pos.X, (int)upper_pipe_pos.Y, lower_pipe.Width, lower_pipe.Height);
            }
        }
        public Pipes()
        {
            upper_pipe = Global.Content.Load<Texture2D>("pipe_up");
            lower_pipe = Global.Content.Load<Texture2D>("pipe_down");
            Random random = new Random();
            int space = random.Next(70, 150);
            lower_pipe_pos = new Vector2(Global.Device.Viewport.Width - lower_pipe.Width, random.Next(50, 215) - lower_pipe.Height);
            upper_pipe_pos = new Vector2(Global.Device.Viewport.Width - upper_pipe.Width, 500 - space - Math.Abs(lower_pipe_pos.Y));

        }
        public void Draw()
        {
            Global.SpriteBatch.Begin();
            Global.SpriteBatch.Draw(upper_pipe, upper_pipe_pos, Color.White);
            Global.SpriteBatch.Draw(lower_pipe, lower_pipe_pos, Color.White);
            Global.SpriteBatch.End();
        }

        public void Update(GameTime gameTime)
        {
            lower_pipe_pos.X -= Speed;
            upper_pipe_pos.X -= Speed;
        }
    }
}
