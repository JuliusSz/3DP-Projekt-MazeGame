using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityComponentSystem
{
    public class GameObject
    {
        #region Private Fields
        private bool isActive = true;
        private Game game;
        private Transform transform;
        private string name;
        private List<IComponent> components = new List<IComponent>();
        #endregion

        #region Public Properties
        public bool IsActive
        {
            get { return isActive; }
            set { isActive = value; }
        }

        public Transform Transform
        {
            get { return transform; }
        }


        public Game Game
        {
            get { return game; }
        }
        #endregion

        #region Public Constructors
        public GameObject(Game game, String name) : this(game, name, Vector3.Zero) { }

        public GameObject(Game game, String name, Vector3 position)
        {
            this.game = game;
            this.name = name;
            transform = new Transform(this, position);
            components.Add(transform);
        }

        #endregion

        #region GameLoop
        public void Update(GameTime gameTime)
        {
            if (isActive)
            {
                foreach(IComponent component in components)
                {
                    if (component.Enabled)
                        component.Update(gameTime);
                }

            }
        }

        public void Draw(Camera currentCamera, GameTime gameTime)
        {
            if (isActive)
            {
                foreach (IComponent component in components)
                {
                    if (component is IDrawableComponent) 
                    { 
                        if (component.Enabled)
                            ((IDrawableComponent) component).Draw(currentCamera, gameTime);
                    }
                }
            }
        }
        #endregion

        #region Public Methods

        public void AddComponent<T>() where T : IComponent
        {
            components.Add((T)Activator.CreateInstance(typeof(T), new GameObject[1] {this }));
        }
        #endregion
    }
}
