using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeProjekt
{
    public class MazeMap
    {
        public Node[,] map = new Node[Maze.Height, Maze.Width];

        public MazeMap()
        {
            for (int x = 0; x < Maze.Width; x++)
                for (int z = 0; z < Maze.Height; z++)
                    map[x, z] = new Node();

            #region first column
            map[0, 0].Walls[0] = true;
            map[0, 0].Walls[1] = false;
            map[0, 0].Walls[2] = false;
            map[0, 0].Walls[3] = true;

            map[0, 1].Walls[0] = false;
            map[0, 1].Walls[1] = true;
            map[0, 1].Walls[2] = false;
            map[0, 1].Walls[3] = true;

            map[0, 2].Walls[0] = false;
            map[0, 2].Walls[1] = true;
            map[0, 2].Walls[2] = false;
            map[0, 2].Walls[3] = true;

            map[0, 3].Walls[0] = false;
            map[0, 3].Walls[1] = false;
            map[0, 3].Walls[2] = false;
            map[0, 3].Walls[3] = true;

            map[0, 4].Walls[0] = false;
            map[0, 4].Walls[1] = true;
            map[0, 4].Walls[2] = false;
            map[0, 4].Walls[3] = true;

            map[0, 5].Walls[0] = false;
            map[0, 5].Walls[1] = false;
            map[0, 5].Walls[2] = true;
            map[0, 5].Walls[3] = true;
            #endregion

            #region second column
            map[1, 0].Walls[0] = true;
            map[1, 0].Walls[1] = false;
            map[1, 0].Walls[2] = true;
            map[1, 0].Walls[3] = false;

            map[1, 1].Walls[0] = true;
            map[1, 1].Walls[1] = false;
            map[1, 1].Walls[2] = false;
            map[1, 1].Walls[3] = true;

            map[1, 2].Walls[0] = false;
            map[1, 2].Walls[1] = true;
            map[1, 2].Walls[2] = false;
            map[1, 2].Walls[3] = true;

            map[1, 3].Walls[0] = false;
            map[1, 3].Walls[1] = false;
            map[1, 3].Walls[2] = true;
            map[1, 3].Walls[3] = false;

            map[1, 4].Walls[0] = true;
            map[1, 4].Walls[1] = false;
            map[1, 4].Walls[2] = false;
            map[1, 4].Walls[3] = true;

            map[1, 5].Walls[0] = false;
            map[1, 5].Walls[1] = true;
            map[1, 5].Walls[2] = true;
            map[1, 5].Walls[3] = false;
            #endregion

            #region third column
            map[2, 0].Walls[0] = true;
            map[2, 0].Walls[1] = false;
            map[2, 0].Walls[2] = true;
            map[2, 0].Walls[3] = false;

            map[2, 1].Walls[0] = true;
            map[2, 1].Walls[1] = true;
            map[2, 1].Walls[2] = false;
            map[2, 1].Walls[3] = false;

            map[2, 2].Walls[0] = false;
            map[2, 2].Walls[1] = true;
            map[2, 2].Walls[2] = true;
            map[2, 2].Walls[3] = true;

            map[2, 3].Walls[0] = true;
            map[2, 3].Walls[1] = false;
            map[2, 3].Walls[2] = true;
            map[2, 3].Walls[3] = false;

            map[2, 4].Walls[0] = true;
            map[2, 4].Walls[1] = true;
            map[2, 4].Walls[2] = false;
            map[2, 4].Walls[3] = false;

            map[2, 5].Walls[0] = false;
            map[2, 5].Walls[1] = false;
            map[2, 5].Walls[2] = true;
            map[2, 5].Walls[3] = true;
            #endregion

            #region fourth column
            map[3, 0].Walls[0] = true;
            map[3, 0].Walls[1] = false;
            map[3, 0].Walls[2] = false;
            map[3, 0].Walls[3] = false;

            map[3, 1].Walls[0] = false;
            map[3, 1].Walls[1] = false;
            map[3, 1].Walls[2] = true;
            map[3, 1].Walls[3] = true;

            map[3, 2].Walls[0] = true;
            map[3, 2].Walls[1] = false;
            map[3, 2].Walls[2] = false;
            map[3, 2].Walls[3] = true;

            map[3, 3].Walls[0] = false;
            map[3, 3].Walls[1] = false;
            map[3, 3].Walls[2] = true;
            map[3, 3].Walls[3] = false;

            map[3, 4].Walls[0] = true;
            map[3, 4].Walls[1] = false;
            map[3, 4].Walls[2] = false;
            map[3, 4].Walls[3] = true;

            map[3, 5].Walls[0] = false;
            map[3, 5].Walls[1] = true;
            map[3, 5].Walls[2] = true;
            map[3, 5].Walls[3] = false;
            #endregion

            #region fifth column
            map[4, 0].Walls[0] = true;
            map[4, 0].Walls[1] = false;
            map[4, 0].Walls[2] = true;
            map[4, 0].Walls[3] = false;

            map[4, 1].Walls[0] = true;
            map[4, 1].Walls[1] = true;
            map[4, 1].Walls[2] = true;
            map[4, 1].Walls[3] = false;

            map[4, 2].Walls[0] = true;
            map[4, 2].Walls[1] = false;
            map[4, 2].Walls[2] = true;
            map[4, 2].Walls[3] = false;

            map[4, 3].Walls[0] = true;
            map[4, 3].Walls[1] = false;
            map[4, 3].Walls[2] = false;
            map[4, 3].Walls[3] = false;

            map[4, 4].Walls[0] = false;
            map[4, 4].Walls[1] = true;
            map[4, 4].Walls[2] = true;
            map[4, 4].Walls[3] = false;

            map[4, 5].Walls[0] = true;
            map[4, 5].Walls[1] = false;
            map[4, 5].Walls[2] = true;
            map[4, 5].Walls[3] = true;
            #endregion

            #region sixth column
            map[5, 0].Walls[0] = true;
            map[5, 0].Walls[1] = true;
            map[5, 0].Walls[2] = false;
            map[5, 0].Walls[3] = false;

            map[5, 1].Walls[0] = false;
            map[5, 1].Walls[1] = true;
            map[5, 1].Walls[2] = false;
            map[5, 1].Walls[3] = true;

            map[5, 2].Walls[0] = false;
            map[5, 2].Walls[1] = true;
            map[5, 2].Walls[2] = true;
            map[5, 2].Walls[3] = false;

            map[5, 3].Walls[0] = true;
            map[5, 3].Walls[1] = true;
            map[5, 3].Walls[2] = false;
            map[5, 3].Walls[3] = false;

            map[5, 4].Walls[0] = false;
            map[5, 4].Walls[1] = true;
            map[5, 4].Walls[2] = false;
            map[5, 4].Walls[3] = true;

            map[5, 5].Walls[0] = false;
            map[5, 5].Walls[1] = true;
            map[5, 5].Walls[2] = true;
            map[5, 5].Walls[3] = false;
            #endregion

        }
    }
}
