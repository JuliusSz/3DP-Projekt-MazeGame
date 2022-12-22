using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGame
{
    public class Scene
    {
        #region variables
        private Game game; //reference to the game
        Maze maze; //maze
        Camera mainCam;
        #endregion

        #region Public Constructors
        /// <summary>
        /// Constructor for Scene that takes in reference to game
        /// </summary>
        /// <param name="game"></param>
        public Scene(Game game)
        {
            this.game = game;
        }
        #endregion

        #region GameLoop
        /// <summary>
        /// creates the Maze and Main Camera
        /// </summary>
        public void Initialize()
        {
            maze = new Maze(game);
            maze.AddMesh<Floor>();
            maze.AddMesh<Wall>();

            //player = new Player(game);
            //player.
             mainCam= new Camera(new Vector3(0.5f, 0.5f, 0.5f), 0, 1.6f, 0.05f, 100f);
        }

        public void Update(GameTime gameTime)
        {

        }

        /// <summary>
        /// Takes in gameTime as argument
        /// for each Camera that is enabled
        /// check if DrawGizmo is enabled
        /// and draw Gizmo Model
        /// then foreach GameObject in scene
        /// Check for Activity and then Draw GameObject
        /// </summary>
        /// <param name="gameTime"></param>
        public void Draw(GameTime gameTime)
        {
            maze.Draw(mainCam);
        }
        #endregion
    }
}
