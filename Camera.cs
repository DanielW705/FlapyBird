using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlapyBird
{
    public class Camera
    {
        public Vector2 Position;
        private Viewport viewport;
        private float cameraSpeed;

        public Camera(Viewport viewport, float speed)
        {
            this.viewport = viewport;
            this.cameraSpeed = speed;
        }

        public void Update(Vector2 birdPosition, GameTime gameTime)
        {
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            float targetX = birdPosition.X - viewport.Width / 2;

            // Interpola la posición de la cámara hacia la del pájaro con una velocidad basada en el tiempo
            Position.X = MathHelper.Lerp(Position.X, targetX, cameraSpeed * deltaTime);
            Position.Y = 0; // Puedes ajustar el eje vertical si es necesario
        }

        public Matrix GetViewMatrix()
        {
            return Matrix.CreateTranslation(new Vector3(-Position, 0));
        }
    }

}
