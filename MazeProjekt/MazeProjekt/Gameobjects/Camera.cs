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
            set{ position = value; 
            }
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

            if (position.Y < 0)
                return;

            // Positions the Camera Horrizonataly
            this.position = position;
            this.rotation = rotation;

            Matrix rotationMatrix = Matrix.CreateRotationY(rotation);
            Vector3 lookAtOffset = Vector3.Transform(baseCameraReference, rotationMatrix);
            lookAt = position + lookAtOffset;
            needViewResync = true;
        }
        #endregion
    }
}
