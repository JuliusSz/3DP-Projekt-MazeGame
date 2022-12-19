using EntityComponentSystem.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace EntityComponentSystem
{
    public class SampleScene : IScene
    {
        private Game game;
        private Model gizmo;
        public Boolean DrawGizmo = true;
        private List<GameObject> gameObjects = new List<GameObject>();

        public SampleScene(Game game) 
        {
            this.game = game;
            
        }

        public void Initialize() 
        {
            gizmo = game.Content.Load<Model>("Gizmo");
            
            GameObject go = new GameObject(game, "MainCamera", new Vector3(12, 0.9f, 40));
            go.AddComponent<Camera>();
            gameObjects.Add(go);

            go = new GameObject(game, "SpaceShip");
            go.AddComponent<ModelRenderer>();
            gameObjects.Add(go);

        }

        public void Update(GameTime gameTime) 
        { 
            foreach(GameObject gameObject in gameObjects)
            {
                if (gameObject.IsActive)
                    gameObject.Update(gameTime);
            }
        }

        public void Draw(GameTime gameTime) 
        {
            foreach (Camera camera in Camera.AllEnabledCameras)
            {
                if (DrawGizmo)
                    gizmo.Draw(Matrix.Identity, camera.View, camera.Projection);
                foreach (GameObject gameObject in gameObjects)
                {
                    if (gameObject.IsActive)
                        gameObject.Draw(camera, gameTime);
                }
            }
        }
    }
}
