using FlapyBird.Globals;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlapyBird.Sprites
{
    internal class Background : Sprite
    {

        private Matrix transform;
        public Background(Texture2D texture, Vector2 position, Matrix transform) : base(texture, position)
        {
            //UpdateTransform(player_position);

            this.transform = transform;
        }
        public void UpdateTransform(float player_position)
        {

        }
        public override void Draw()
        {
            Global.SpriteBatch.Begin(transformMatrix: transform);
            Global.SpriteBatch.Draw(this.Texture, this.Position, Color.White);
            Global.SpriteBatch.End();

        }
    }
}
