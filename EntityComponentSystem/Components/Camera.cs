using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EntityComponentSystem
{
    public class Camera : IComponent
    {
        #region Private Fields
        private bool enabled = true;
        private GameObject gameObject;
        private Matrix projection;
        private float nearPlaneDistance = 1f;
        private float farPlaneDistance = 100f;
        private float fieldOfView = MathHelper.PiOver4;
        private float aspectRatio = 1.6f;
        private Viewport viewport;

        private static List<Camera> allCameras = new List<Camera>();
        #endregion

        #region Public Properties
        public bool Enabled
        {
            get { return enabled; }
            set { enabled = value; }
        }

        public static List<Camera> AllCameras
        {
            get { return allCameras; }
        }

        public static List<Camera> AllEnabledCameras
        {
            get { return allCameras.Where(c => c.enabled == true).ToList(); }
        }

        public Matrix Projection
        {
            get { return projection; }
        }

        public Matrix View
        {
            get { return gameObject.Transform.WorldToLocal; }
        }

        public float FieldOfViewRad
        {
            get { return fieldOfView; }
            set
            { if (value <= 0 || value >= MathHelper.Pi)
                    throw new InvalidOperationException("Fehler bei Camera.FieldOfViewRad: es sind nur Werte zwischen 0 und Pi erlaubt");
                aspectRatio = value;
                UpdateProjectionMatrix();
            }
        }

        public float FieldOfViewDeg
        {
            get { return MathHelper.ToDegrees(fieldOfView); }
            set
            {
                if (value <= 0 || value >= 180)
                    throw new InvalidOperationException("Fehler bei Camera.FieldOfViewRad: es sind nur Werte zwischen 0 und Pi erlaubt");
                aspectRatio = MathHelper.ToRadians(value);
                UpdateProjectionMatrix();
            }
        }

        public float NearPlaneDistance
        {
            get { return nearPlaneDistance; }
            set
            {
                if (value <= 0 || value >= farPlaneDistance)
                    throw new InvalidOperationException("Fehler bei Camera.NearPlaneDistance: muss größer 0 und kleiner als die FarPlaneDistance sein");
                nearPlaneDistance = value;
                UpdateProjectionMatrix();
            }
        }

        public float FarPlaneDistance
        {
            get { return farPlaneDistance; }
            set
            {
                if (value <= nearPlaneDistance)
                    throw new InvalidOperationException("Fehler bei Camera.FarPlaneDistance: muss größer sein als die NearPlaneDistance sein");
                farPlaneDistance = value;
                UpdateProjectionMatrix();
            }
        }

        public float AspectRatio
        {
            get { return aspectRatio; }
            set
            {
                if (value <= 0)
                    throw new InvalidOperationException("Fehler bei Camera.AspectRatio: muss größer als 0 sein");
                aspectRatio = value;
                UpdateProjectionMatrix();
            }
        }

        public Viewport Viewport
        {
            get { return viewport; }
            set { viewport = value; }
        }
        #endregion

        #region Public Constructors
        public Camera(GameObject gameObject)
        {
            Camera.allCameras.Add(this);
            this.gameObject = gameObject;
            aspectRatio = gameObject.Game.GraphicsDevice.Viewport.AspectRatio;
            UpdateProjectionMatrix();
        }
        #endregion

        #region GameLoop
        public void Update(GameTime gametime)
        {

        }
        #endregion

        #region Private Methods
        private void UpdateProjectionMatrix()
        {
            projection = Matrix.CreatePerspectiveFieldOfView(fieldOfView, aspectRatio,
                                                   nearPlaneDistance, farPlaneDistance);
        }
        #endregion
    }
}
