using EntityComponentSystem.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace EntityComponentSystem
{
    public class SampleScene : IScene
    {
        #region Private Fields
        private Game game;
        private Model gizmo;
        public Boolean DrawGizmo = true;
        private List<GameObject> gameObjects = new List<GameObject>();
        #endregion

        #region Public Constructors
        public SampleScene(Game game) 
        {
            this.game = game;
            
        }
        #endregion

        #region GameLoop
        public void Initialize() 
        {
            gizmo = game.Content.Load<Model>("Gizmo");
            
            GameObject go = new GameObject(game, "MainCamera", new Vector3(0f, 0f, 35f));
            go.AddComponent<Camera>();
            gameObjects.Add(go);

            go = new GameObject(game, "SpaceShip", new Vector3(-10, 0, -5));
            go.AddComponent<ModelRenderer>();
            gameObjects.Add(go);

            go = new GameObject(game, "Trianlgle");
            go.AddComponent<MeshRenderer>();
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
        #endregion
    }
}
