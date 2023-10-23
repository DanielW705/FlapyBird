﻿using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlapyBird.Cameras
{
    public class Camera
    {
        public Vector2 Position;

        private Viewport viewport;

        public float cameraSpeed;

        public Camera(Viewport viewport, float speed)
        {
            this.viewport = viewport;
            cameraSpeed = speed;
        }

        public void Update(Vector2 birdPosition, GameTime gameTime, float mult = 1.0f)
        {
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            float targetX = birdPosition.X - viewport.Width / 2;

            if (mult > 1.0f)
            {
                // Interpola la posición de la cámara hacia la del pájaro con una velocidad basada en el tiempo
                Position.X = MathHelper.Lerp(Position.X, targetX, cameraSpeed * mult * deltaTime);
                Position.Y = 0; // Puedes ajustar el eje vertical si es necesario
            }
            else
            {
                // Interpola la posición de la cámara hacia la del pájaro con una velocidad basada en el tiempo
                Position.X = MathHelper.Lerp(Position.X, targetX, cameraSpeed * deltaTime);
                Position.Y = 0; // Puedes ajustar el eje vertical si es necesario
            }
        }

        public Matrix GetViewMatrix()
        {
            return Matrix.CreateTranslation(new Vector3(-Position, 0));
        }
    }

}
