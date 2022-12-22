using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGame
{
    public class Maze
    {
        #region Fields
        public const int Width = 10;
        public const int Height = 10;
        public Game game;
        List<IMesh> meshes = new List<IMesh>();
        #endregion

        #region Constructor
        public Maze(Game game)
        {
            this.game = game;
        }
        #endregion
        

        #region Draw
        public void Draw(Camera camera)
        {
            foreach (IMesh mesh in meshes)
            {
                mesh.Draw(camera);
            }
        }
        #endregion

        #region methods
        /// <summary>
        /// adds meshes to list of meshes in this GameObject
        /// T becomes the type of component 
        /// a type of component is any component that implements IComponent
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public void AddMesh<T>() where T : IMesh
        {
            meshes.Add((T)Activator.CreateInstance(typeof(T), new Maze[1] { this }));
        }
        #endregion
    }
}
