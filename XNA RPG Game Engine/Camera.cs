using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;

namespace Test
{
    public class Camera
    {
        //M11 = X Scale
        //M2 = Rotation
        //M4 = Translation
        float Zoom;
        Matrix Transform;
        Vector2 Position;
        public Vector2 TextBoxPos;
        float Rotation;
        public Camera()
        {
            Zoom = 1.0f;
            Rotation = 0.0f;
            Position = Vector2.Zero;
        }
        public void SetZoom(float zoom)
        {
            Zoom = zoom;
        }
        public float GetZoom()
        {
            return Zoom;
        } 
        public void Update(GameTime gameTime)
        {
            Transform = Matrix.CreateRotationZ(Rotation) * Matrix.CreateScale(Zoom) * Matrix.CreateTranslation(Position.X, Position.Y, 0);
        }
        public Matrix GetTransformMatrix(GraphicsDevice graphicsDevice)
        {
            return Transform;
        }
        public void SetPosition(Vector2 position)
        {
            Position = position;
        }
        public Vector2 GetPosition()
        {
            return Position;
        }
        public void SetPositionY(float Y)
        {
            Position.Y = Y;
        }
        public void SetPositionX(float X)
        {
            Position.X = X;
        }
        public Vector2 GetTextBoxPosition()
        {
            return TextBoxPos;
        }
        public void SetTextBoxPositionY(float Y)
        {
            TextBoxPos.Y = Y;
        }
        public void SetTextBoxPositionX(float X)
        {
            TextBoxPos.X = X;
        }
        public float GetPositionY()
        {
            return Position.Y;
        }
        public float GetPositionX()
        {
            return Position.X;
        }
        public void SetRotation(float rotation)
        {
            Rotation = rotation;
        }
        public float GetRotation()
        {
            return Rotation;
        }
    }
}
