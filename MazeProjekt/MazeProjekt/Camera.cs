using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeProjekt
{
    public class Camera
    {
        #region Fields
        private Vector3 position = Vector3.Zero;
        private float rotation;
        private Vector3 lookAt;
        private Vector3 baseCameraReference = new Vector3(0, 0, 1);
        private bool needViewResync = true;
        private Matrix cachedViewMatrix;
        #endregion

        #region Properties
        public Matrix Projection { get; private set; }
        public Vector3 Position
        {
            get{ return position; }
            set{ position = value; UpdateLookAtHor(); }
        }

        public float Rotation
        {
            get{ return rotation; }
            set{ rotation = value; }
        }
        public Matrix View
        {
            get 
            {
                if (needViewResync)
                    cachedViewMatrix = Matrix.CreateLookAt(Position, lookAt, Vector3.Up);
                return cachedViewMatrix;
            }
        }
        #endregion

        #region Constructor
        public Camera(Vector3 position, float rotation, float aspectRatio, float nearClip, float farClip)
        {
            Projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver4, aspectRatio, nearClip, farClip);
            MoveTo(position, rotation);
        }
        #endregion

        #region Helper Methods
        public void MoveTo(Vector3 position, float rotation)
        {
            if (position.Y < 0)
                return;
            this.position = position;
            this.rotation = rotation;
            UpdateLookAtHor();
        }
        public void UpdateLookAtHor()
        {
            Matrix rotationMatrix = Matrix.CreateRotationY(rotation);
            Vector3 lookAtOffset = Vector3.Transform(baseCameraReference, rotationMatrix);
            lookAt = position + lookAtOffset;
            needViewResync = true;
        }

        public void UpdateLookAtVer()
        {
            Matrix rotationMatrix = Matrix.CreateRotationX(rotation);
            Vector3 lookAtOffset = Vector3.Transform(baseCameraReference, rotationMatrix);
            lookAt = position + lookAtOffset;
            needViewResync = true;
        }

        public Vector3 PreviewMove(float scale)
        {
            Matrix rotate = Matrix.CreateRotationY(rotation);
            Vector3 forward = new Vector3(0, 0, scale);
            forward = Vector3.Transform(forward, rotate);
            return (position + forward);
        }

        public void MoveForward(float scale)
        {
            MoveTo(PreviewMove(scale), rotation);
        }

        public Vector3 PreviewMoveUp(float scale)
        {
            Matrix rotate = Matrix.CreateRotationY(rotation);
            Vector3 upward = new Vector3(0, scale, 0);
            upward = Vector3.Transform(upward, rotate);
            return (position + upward);
        }
        public void MoveUpward(float scale)
        {
            MoveTo(PreviewMoveUp(scale), rotation);
        }
        #endregion


    }
}
