using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;


namespace EntityComponentSystem.Components
{
    public class MeshRenderer :IComponent, IDrawableComponent
    {
        #region Private Fields
        private bool enabled = true;
        private GameObject gameObject;
        private VertexPositionColor[] vertices;
        private BasicEffect effect;
        #endregion

        #region Public Properties
        public bool Enabled
        {
            get { return enabled; }
            set { enabled = value; }
        }
        #endregion

        #region Public Constructors
        public MeshRenderer(GameObject gameObject)
        {
            this.gameObject = gameObject;
            effect = new BasicEffect(gameObject.Game.GraphicsDevice) { VertexColorEnabled = true };

            vertices = new VertexPositionColor[3];
            vertices[0] = new VertexPositionColor(new Vector3(0, 10, 0), Color.Purple);
            vertices[1] = new VertexPositionColor(new Vector3(10, -10, 0), Color.Yellow);
            vertices[2] = new VertexPositionColor(new Vector3(-10, -10, 0), Color.Blue);
        }
        #endregion

        #region GameLoop
        public void Update(GameTime gameTime)
        {

        }

        public void Draw(Camera camera, GameTime gameTime)
        {
            effect.World = gameObject.Transform.LocalToWorld;
            effect.View = camera.View;
            effect.Projection = camera.Projection;
            effect.CurrentTechnique.Passes[0].Apply();

            gameObject.Game.GraphicsDevice.DrawUserPrimitives(PrimitiveType.TriangleList,
                                                                         vertices, 0, 1);
        }

        #endregion

        #region Public Methods
        #endregion

        #region Private Methods
        #endregion
    }
}
