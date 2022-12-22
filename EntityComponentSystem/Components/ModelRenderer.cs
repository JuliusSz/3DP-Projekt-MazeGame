using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace EntityComponentSystem.Components
{
    public class ModelRenderer : IComponent, IDrawableComponent
    {
        private bool enabled = true;
        private GameObject gameObject;
        private Model model;

        public bool Enabled
        {
            get { return enabled; }
            set { enabled = value; }
        }

        public ModelRenderer(GameObject gameObject)
        {
            this.gameObject = gameObject;
            model = gameObject.Game.Content.Load<Model>("spaceship");
        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(Camera camera, GameTime gameTime)
        {
            model.Draw(gameObject.Transform.LocalToWorld, camera.View, camera.Projection);
        }
    }
}
