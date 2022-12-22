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
            //every Code-Block describes one Block on the maze

            //back
            map[0, 0].Walls[0] = true;
            //left
            map[0, 0].Walls[1] = true;
            //front
            map[0, 0].Walls[2] = false;
            //right
            map[0, 0].Walls[3] = true;

            map[0, 1].Walls[0] = false;
            map[0, 1].Walls[1] = true;
            map[0, 1].Walls[2] = false;
            map[0, 1].Walls[3] = true;

            map[0, 2].Walls[0] = true;
            map[0, 2].Walls[1] = false;
            map[0, 2].Walls[2] = false;
            map[0, 2].Walls[3] = true;

            map[0, 3].Walls[0] = false;
            map[0, 3].Walls[1] = true;
            map[0, 3].Walls[2] = false;
            map[0, 3].Walls[3] = true;

            map[0, 4].Walls[0] = false;
            map[0, 4].Walls[1] = false;
            map[0, 4].Walls[2] = true;
            map[0, 4].Walls[3] = true;

            map[0, 5].Walls[0] = true;
            map[0, 5].Walls[1] = false;
            map[0, 5].Walls[2] = false;
            map[0, 5].Walls[3] = true;

            map[0, 6].Walls[0] = false;
            map[0, 6].Walls[1] = true;
            map[0, 6].Walls[2] = true;
            map[0, 6].Walls[3] = true;

            map[0, 7].Walls[0] = true;
            map[0, 7].Walls[1] = false;
            map[0, 7].Walls[2] = false;
            map[0, 7].Walls[3] = true;

            map[0, 8].Walls[0] = false;
            map[0, 8].Walls[1] = true;
            map[0, 8].Walls[2] = false;
            map[0, 8].Walls[3] = true;

            map[0, 9].Walls[0] = false;
            map[0, 9].Walls[1] = true;
            map[0, 9].Walls[2] = true;
            map[0, 9].Walls[3] = true;
            #endregion

            #region second column
            map[1, 0].Walls[0] = true;
            map[1, 0].Walls[1] = false;
            map[1, 0].Walls[2] = false;
            map[1, 0].Walls[3] = true;

            map[1, 1].Walls[0] = false;
            map[1, 1].Walls[1] = true;
            map[1, 1].Walls[2] = true;
            map[1, 1].Walls[3] = true;

            map[1, 2].Walls[0] = true;
            map[1, 2].Walls[1] = false;
            map[1, 2].Walls[2] = true;
            map[1, 2].Walls[3] = false;

            map[1, 3].Walls[0] = true;
            map[1, 3].Walls[1] = false;
            map[1, 3].Walls[2] = false;
            map[1, 3].Walls[3] = true;

            map[1, 4].Walls[0] = false;
            map[1, 4].Walls[1] = true;
            map[1, 4].Walls[2] = true;
            map[1, 4].Walls[3] = false;

            map[1, 5].Walls[0] = true;
            map[1, 5].Walls[1] = false;
            map[1, 5].Walls[2] = true;
            map[1, 5].Walls[3] = false;

            map[1, 6].Walls[0] = true;
            map[1, 6].Walls[1] = false;
            map[1, 6].Walls[2] = false;
            map[1, 6].Walls[3] = true;

            map[1, 7].Walls[0] = false;
            map[1, 7].Walls[1] = true;
            map[1, 7].Walls[2] = true;
            map[1, 7].Walls[3] = false;

            map[1, 8].Walls[0] = true;
            map[1, 8].Walls[1] = true;
            map[1, 8].Walls[2] = false;
            map[1, 8].Walls[3] = true;

            map[1, 9].Walls[0] = false;
            map[1, 9].Walls[1] = false;
            map[1, 9].Walls[2] = true;
            map[1, 9].Walls[3] = true;
            #endregion

            #region third column
            map[2, 0].Walls[0] = true;
            map[2, 0].Walls[1] = true;
            map[2, 0].Walls[2] = false;
            map[2, 0].Walls[3] = false;

            map[2, 1].Walls[0] = false;
            map[2, 1].Walls[1] = true;
            map[2, 1].Walls[2] = false;
            map[2, 1].Walls[3] = true;

            map[2, 2].Walls[0] = false;
            map[2, 2].Walls[1] = false;
            map[2, 2].Walls[2] = true;
            map[2, 2].Walls[3] = false;

            map[2, 3].Walls[0] = true;
            map[2, 3].Walls[1] = true;
            map[2, 3].Walls[2] = false;
            map[2, 3].Walls[3] = false;

            map[2, 4].Walls[0] = false;
            map[2, 4].Walls[1] = true;
            map[2, 4].Walls[2] = false;
            map[2, 4].Walls[3] = true;

            map[2, 5].Walls[0] = false;
            map[2, 5].Walls[1] = true;
            map[2, 5].Walls[2] = false;
            map[2, 5].Walls[3] = false;

            map[2, 6].Walls[0] = false;
            map[2, 6].Walls[1] = false;
            map[2, 6].Walls[2] = true;
            map[2, 6].Walls[3] = false;

            map[2, 7].Walls[0] = true;
            map[2, 7].Walls[1] = false;
            map[2, 7].Walls[2] = false;
            map[2, 7].Walls[3] = true;

            map[2, 8].Walls[0] = false;
            map[2, 8].Walls[1] = false;
            map[2, 8].Walls[2] = true;
            map[2, 8].Walls[3] = true;

            map[2, 9].Walls[0] = true;
            map[2, 9].Walls[1] = false;
            map[2, 9].Walls[2] = true;
            map[2, 9].Walls[3] = false;
            #endregion

            #region fourth column
            map[3, 0].Walls[0] = true;
            map[3, 0].Walls[1] = false;
            map[3, 0].Walls[2] = false;
            map[3, 0].Walls[3] = true;

            map[3, 1].Walls[0] = false;
            map[3, 1].Walls[1] = false;
            map[3, 1].Walls[2] = true;
            map[3, 1].Walls[3] = true;

            map[3, 2].Walls[0] = true;
            map[3, 2].Walls[1] = true;
            map[3, 2].Walls[2] = false;
            map[3, 2].Walls[3] = false;

            map[3, 3].Walls[0] = false;
            map[3, 3].Walls[1] = false;
            map[3, 3].Walls[2] = false;
            map[3, 3].Walls[3] = true;

            map[3, 4].Walls[0] = false;
            map[3, 4].Walls[1] = true;
            map[3, 4].Walls[2] = false;
            map[3, 4].Walls[3] = true;

            map[3, 5].Walls[0] = false;
            map[3, 5].Walls[1] = false;
            map[3, 5].Walls[2] = false;
            map[3, 5].Walls[3] = true;

            map[3, 6].Walls[0] = false;
            map[3, 6].Walls[1] = true;
            map[3, 6].Walls[2] = true;
            map[3, 6].Walls[3] = false;

            map[3, 7].Walls[0] = true;
            map[3, 7].Walls[1] = false;
            map[3, 7].Walls[2] = true;
            map[3, 7].Walls[3] = false;

            map[3, 8].Walls[0] = true;
            map[3, 8].Walls[1] = false;
            map[3, 8].Walls[2] = true;
            map[3, 8].Walls[3] = false;

            map[3, 9].Walls[0] = true;
            map[3, 9].Walls[1] = false;
            map[3, 9].Walls[2] = true;
            map[3, 9].Walls[3] = false;
            #endregion

            #region fifth column
            map[4, 0].Walls[0] = true;
            map[4, 0].Walls[1] = false;
            map[4, 0].Walls[2] = true;
            map[4, 0].Walls[3] = false;

            map[4, 1].Walls[0] = true;
            map[4, 1].Walls[1] = false;
            map[4, 1].Walls[2] = true;
            map[4, 1].Walls[3] = false;

            map[4, 2].Walls[0] = true;
            map[4, 2].Walls[1] = false;
            map[4, 2].Walls[2] = true;
            map[4, 2].Walls[3] = true;

            map[4, 3].Walls[0] = true;
            map[4, 3].Walls[1] = false;
            map[4, 3].Walls[2] = true;
            map[4, 3].Walls[3] = false;

            map[4, 4].Walls[0] = true;
            map[4, 4].Walls[1] = true;
            map[4, 4].Walls[2] = true;
            map[4, 4].Walls[3] = true;

            map[4, 5].Walls[0] = true;
            map[4, 5].Walls[1] = false;
            map[4, 5].Walls[2] = true;
            map[4, 5].Walls[3] = false;

            map[4, 6].Walls[0] = true;
            map[4, 6].Walls[1] = false;
            map[4, 6].Walls[2] = false;
            map[4, 6].Walls[3] = true;

            map[4, 7].Walls[0] = false;
            map[4, 7].Walls[1] = true;
            map[4, 7].Walls[2] = true;
            map[4, 7].Walls[3] = false;

            map[4, 8].Walls[0] = true;
            map[4, 8].Walls[1] = false;
            map[4, 8].Walls[2] = false;
            map[4, 8].Walls[3] = false;

            map[4, 9].Walls[0] = false;
            map[4, 9].Walls[1] = true;
            map[4, 9].Walls[2] = true;
            map[4, 9].Walls[3] = false;
            #endregion

            #region sixth column
            map[5, 0].Walls[0] = true;
            map[5, 0].Walls[1] = false;
            map[5, 0].Walls[2] = true;
            map[5, 0].Walls[3] = false;

            map[5, 1].Walls[0] = true;
            map[5, 1].Walls[1] = false;
            map[5, 1].Walls[2] = true;
            map[5, 1].Walls[3] = false;

            map[5, 2].Walls[0] = true;
            map[5, 2].Walls[1] = false;
            map[5, 2].Walls[2] = true;
            map[5, 2].Walls[3] = false;

            map[5, 3].Walls[0] = true;
            map[5, 3].Walls[1] = true;
            map[5, 3].Walls[2] = false;
            map[5, 3].Walls[3] = false;

            map[5, 4].Walls[0] = false;
            map[5, 4].Walls[1] = false;
            map[5, 4].Walls[2] = false;
            map[5, 4].Walls[3] = true;

            map[5, 5].Walls[0] = false;
            map[5, 5].Walls[1] = true;
            map[5, 5].Walls[2] = true;
            map[5, 5].Walls[3] = false;

            map[5, 6].Walls[0] = true;
            map[5, 6].Walls[1] = false;
            map[5, 6].Walls[2] = true;
            map[5, 6].Walls[3] = false;

            map[5, 7].Walls[0] = true;
            map[5, 7].Walls[1] = false;
            map[5, 7].Walls[2] = false;
            map[5, 7].Walls[3] = true;

            map[5, 8].Walls[0] = false;
            map[5, 8].Walls[1] = true;
            map[5, 8].Walls[2] = true;
            map[5, 8].Walls[3] = false;

            map[5, 9].Walls[0] = true;
            map[5, 9].Walls[1] = false;
            map[5, 9].Walls[2] = true;
            map[5, 9].Walls[3] = true;
            #endregion

            #region seventh column
            map[6, 0].Walls[0] = true;
            map[6, 0].Walls[1] = false;
            map[6, 0].Walls[2] = true;
            map[6, 0].Walls[3] = false;

            map[6, 1].Walls[0] = true;
            map[6, 1].Walls[1] = false;
            map[6, 1].Walls[2] = true;
            map[6, 1].Walls[3] = false;

            map[6, 2].Walls[0] = true;
            map[6, 2].Walls[1] = true;
            map[6, 2].Walls[2] = false;
            map[6, 2].Walls[3] = false;

            map[6, 3].Walls[0] = false;
            map[6, 3].Walls[1] = false;
            map[6, 3].Walls[2] = true;
            map[6, 3].Walls[3] = true;

            map[6, 4].Walls[0] = true;
            map[6, 4].Walls[1] = true;
            map[6, 4].Walls[2] = false;
            map[6, 4].Walls[3] = false;

            map[6, 5].Walls[0] = false;
            map[6, 5].Walls[1] = true;
            map[6, 5].Walls[2] = false;
            map[6, 5].Walls[3] = true;

            map[6, 6].Walls[0] = false;
            map[6, 6].Walls[1] = true;
            map[6, 6].Walls[2] = true;
            map[6, 6].Walls[3] = false;

            map[6, 7].Walls[0] = true;
            map[6, 7].Walls[1] = false;
            map[6, 7].Walls[2] = false;
            map[6, 7].Walls[3] = false;

            map[6, 8].Walls[0] = false;
            map[6, 8].Walls[1] = true;
            map[6, 8].Walls[2] = false;
            map[6, 8].Walls[3] = true;

            map[6, 9].Walls[0] = false;
            map[6, 9].Walls[1] = true;
            map[6, 9].Walls[2] = true;
            map[6, 9].Walls[3] = false;
            #endregion

            #region eight column
            map[7, 0].Walls[0] = true;
            map[7, 0].Walls[1] = false;
            map[7, 0].Walls[2] = true;
            map[7, 0].Walls[3] = false;

            map[7, 1].Walls[0] = true;
            map[7, 1].Walls[1] = false;
            map[7, 1].Walls[2] = true;
            map[7, 1].Walls[3] = false;

            map[7, 2].Walls[0] = true;
            map[7, 2].Walls[1] = true;
            map[7, 2].Walls[2] = false;
            map[7, 2].Walls[3] = true;

            map[7, 3].Walls[0] = true;
            map[7, 3].Walls[1] = false;
            map[7, 3].Walls[2] = false;
            map[7, 3].Walls[3] = false;

            map[7, 4].Walls[0] = false;
            map[7, 4].Walls[1] = false;
            map[7, 4].Walls[2] = false;
            map[7, 4].Walls[3] = true;

            map[7, 5].Walls[0] = false;
            map[7, 5].Walls[1] = false;
            map[7, 5].Walls[2] = false;
            map[7, 5].Walls[3] = true;

            map[7, 6].Walls[0] = false;
            map[7, 6].Walls[1] = true;
            map[7, 6].Walls[2] = false;
            map[7, 6].Walls[3] = true;

            map[7, 7].Walls[0] = false;
            map[7, 7].Walls[1] = false;
            map[7, 7].Walls[2] = true;
            map[7, 7].Walls[3] = false;

            map[7, 8].Walls[0] = true;
            map[7, 8].Walls[1] = true;
            map[7, 8].Walls[2] = false;
            map[7, 8].Walls[3] = true;

            map[7, 9].Walls[0] = false;
            map[7, 9].Walls[1] = false;
            map[7, 9].Walls[2] = true;
            map[7, 9].Walls[3] = true;
            #endregion

            #region ninth column
            map[8, 0].Walls[0] = true;
            map[8, 0].Walls[1] = false;
            map[8, 0].Walls[2] = true;
            map[8, 0].Walls[3] = false;

            map[8, 1].Walls[0] = true;
            map[8, 1].Walls[1] = true;
            map[8, 1].Walls[2] = true;
            map[8, 1].Walls[3] = false;

            map[8, 2].Walls[0] = true;
            map[8, 2].Walls[1] = false;
            map[8, 2].Walls[2] = true;
            map[8, 2].Walls[3] = false;

            map[8, 3].Walls[0] = true;
            map[8, 3].Walls[1] = true;
            map[8, 3].Walls[2] = true;
            map[8, 3].Walls[3] = false;

            map[8, 4].Walls[0] = true;
            map[8, 4].Walls[1] = false;
            map[8, 4].Walls[2] = true;
            map[8, 4].Walls[3] = false;

            map[8, 5].Walls[0] = true;
            map[8, 5].Walls[1] = false;
            map[8, 5].Walls[2] = true;
            map[8, 5].Walls[3] = false;

            map[8, 6].Walls[0] = false;
            map[8, 6].Walls[1] = true;
            map[8, 6].Walls[2] = true;
            map[8, 6].Walls[3] = true;

            map[8, 7].Walls[0] = false;
            map[8, 7].Walls[1] = true;
            map[8, 7].Walls[2] = false;
            map[8, 7].Walls[3] = false;

            map[8, 8].Walls[0] = false;
            map[8, 8].Walls[1] = true;
            map[8, 8].Walls[2] = false;
            map[8, 8].Walls[3] = true;

            map[8, 9].Walls[0] = false;
            map[8, 9].Walls[1] = false;
            map[8, 9].Walls[2] = true;
            map[8, 9].Walls[3] = false;

            #endregion

            #region tenth column
            map[9, 0].Walls[0] = true;
            map[9, 0].Walls[1] = true;
            map[9, 0].Walls[2] = false;
            map[9, 0].Walls[3] = false;

            map[9, 1].Walls[0] = false;
            map[9, 1].Walls[1] = true;
            map[9, 1].Walls[2] = false;
            map[9, 1].Walls[3] = true;

            map[9, 2].Walls[0] = false;
            map[9, 2].Walls[1] = true;
            map[9, 2].Walls[2] = true;
            map[9, 2].Walls[3] = false;

            map[9, 3].Walls[0] = false;
            map[9, 3].Walls[1] = true;
            map[9, 3].Walls[2] = false;
            map[9, 3].Walls[3] = true;

            map[9, 4].Walls[0] = false;
            map[9, 4].Walls[1] = true;
            map[9, 4].Walls[2] = true;
            map[9, 4].Walls[3] = false;

            map[9, 5].Walls[0] = true;
            map[9, 5].Walls[1] = true;
            map[9, 5].Walls[2] = false;
            map[9, 5].Walls[3] = false;

            map[9, 6].Walls[0] = false;
            map[9, 6].Walls[1] = true;
            map[9, 6].Walls[2] = false;
            map[9, 6].Walls[3] = true;

            map[9, 7].Walls[0] = false;
            map[9, 7].Walls[1] = true;
            map[9, 7].Walls[2] = false;
            map[9, 7].Walls[3] = true;

            map[9, 8].Walls[0] = false;
            map[9, 8].Walls[1] = true;
            map[9, 8].Walls[2] = true;
            map[9, 8].Walls[3] = true;

            map[9, 9].Walls[0] = true;
            map[9, 9].Walls[1] = true;
            map[9, 9].Walls[2] = true;
            map[9, 9].Walls[3] = false;
            #endregion
        }
    }
}
