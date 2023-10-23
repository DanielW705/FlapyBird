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
    public class Player : Sprite
    {
        public bool HasDied = false;

        private float gravity = 0.7f; // la fuerza de gravedad que se aplica en el movimiento horizontal

        private Vector2 velocity = Vector2.Zero; // variable para el movimiento vertical

        public Player(Texture2D texture, Vector2 position, float speed) : base(texture, position)
        {
            this.Speed = speed;
        }
        public override void Update(GameTime gameTime, float mult = 1.0f)
        {
            if (this.Position.Y > Global.Device.Viewport.Height)
                this.HasDied = true;
            else if (this.Position.Y < 0)
                this.HasDied = true;
            else
            {
                float t = (float)gameTime.ElapsedGameTime.Seconds;

                // Se aplica la gravedad en la veloci dad de manera vertical
                velocity.Y += gravity;

                //La posicion va a cambiar conforme a la velocidad
                Position.X += Speed * t;

                // Cuando se de el  espacio se va adquirir el estado en el que esta

                if (Keyboard.GetState().IsKeyDown(Keys.Space))
                    //Se le va afectar la inercia al pajaro para que la gravedad afecte
                    velocity.Y = -8f;

                // Se va a modificar la posicion de manera vertical
                Position.Y += velocity.Y;

            }
        }

    }
}
