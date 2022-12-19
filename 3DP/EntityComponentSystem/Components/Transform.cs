using Microsoft.Xna.Framework;
using System;

namespace EntityComponentSystem
{
    public class Transform : IComponent
    {
        #region Private Fields
        private GameObject gameObject;
        private bool enabled = true;
        private Matrix localToWorld = Matrix.Identity;
        #endregion

        #region Public Properties
        public bool Enabled
        {
            get { return enabled; }
            set { enabled = value; }
        }
        public Matrix LocalToWorld
        {
            get { return localToWorld; }
        }

        public Matrix WorldToLocal
        {
            get { return Matrix.Invert(localToWorld); }
        }
        #endregion

        #region Public Constructors
        public Transform(GameObject gameObject) : this(gameObject, Vector3.Zero) { }
        
        public Transform(GameObject gameObject, Vector3 position)
        {
            this.gameObject = gameObject;
            localToWorld.Translation = position;
        }
        #endregion

        #region GameLoop
        public void Update(GameTime gametime)
        {

        }
        #endregion
    }
}
