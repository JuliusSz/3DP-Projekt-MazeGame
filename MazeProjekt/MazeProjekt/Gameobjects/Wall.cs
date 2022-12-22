using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGame
{
    public class Wall : IMesh
    {
        private Maze maze;
        private GraphicsDevice device;
        private VertexBuffer vertexBuffer;
        private BasicEffect effect;
        private Random rand = new Random();
        public Node[,] mazeMap = new MazeMap().map;
        Vector3[] wallPoints = new Vector3[8];
        Color wallColors = Color.DarkGray;
        public GraphicsDevice Device { get { return device; } set { device = value; } }
        public VertexBuffer VertexBuffer { get { return vertexBuffer; } set { vertexBuffer = value; } }
        public BasicEffect Effect { get { return effect; } set { effect = value; } }

        #region Constructor
        public Wall(Maze maze)
        {
            this.maze = maze;
            this.device = maze.game.GraphicsDevice;
            effect = new BasicEffect(device) { VertexColorEnabled = true };

            wallPoints[0] = new Vector3(0, 1, 0);
            wallPoints[1] = new Vector3(0, 1, 1);
            wallPoints[2] = new Vector3(0, 0, 0);
            wallPoints[3] = new Vector3(0, 0, 1);
            wallPoints[4] = new Vector3(1, 1, 0);
            wallPoints[5] = new Vector3(1, 1, 1);
            wallPoints[6] = new Vector3(1, 0, 0);
            wallPoints[7] = new Vector3(1, 0, 1);

            CreateBuffer();
        }
        #endregion

        #region Buffer Build

        //creates a Vertex Buffer
        public void CreateBuffer()
        {
            List<VertexPositionColor> wallVertexList = new List<VertexPositionColor>();

            for (int x = 0; x < Maze.Height; x++)
            {
                for (int z = 0; z < Maze.Height; z++)
                {
                    foreach (VertexPositionColor vertex in CreatePolys(0, x, z, Color.Red))
                        wallVertexList.Add(vertex);
                }
            }
            vertexBuffer = new VertexBuffer(device, VertexPositionColor.VertexDeclaration, wallVertexList.Count, BufferUsage.WriteOnly);
            vertexBuffer.SetData<VertexPositionColor>(wallVertexList.ToArray());
        }
        
        //Creates a list of Polys that Define a wall
        public List<VertexPositionColor> CreatePolys(int point, int x, int z, Color color)
        {
            List<VertexPositionColor> triangles = new List<VertexPositionColor>();

            if (mazeMap[x, z].Walls[0])
            {
                triangles.Add(CalcPoint(0, x, z, wallColors));
                triangles.Add(CalcPoint(4, x, z, wallColors));
                triangles.Add(CalcPoint(2, x, z, wallColors));
                triangles.Add(CalcPoint(4, x, z, wallColors));
                triangles.Add(CalcPoint(6, x, z, wallColors));
                triangles.Add(CalcPoint(2, x, z, wallColors));
            }

            if (mazeMap[x, z].Walls[1])
            {
                triangles.Add(CalcPoint(4, x, z, wallColors));
                triangles.Add(CalcPoint(5, x, z, wallColors));
                triangles.Add(CalcPoint(6, x, z, wallColors));
                triangles.Add(CalcPoint(5, x, z, wallColors));
                triangles.Add(CalcPoint(7, x, z, wallColors));
                triangles.Add(CalcPoint(6, x, z, wallColors));
            }

            if (mazeMap[x, z].Walls[2])
            {
                triangles.Add(CalcPoint(5, x, z, wallColors));
                triangles.Add(CalcPoint(1, x, z, wallColors));
                triangles.Add(CalcPoint(7, x, z, wallColors));
                triangles.Add(CalcPoint(1, x, z, wallColors));
                triangles.Add(CalcPoint(3, x, z, wallColors));
                triangles.Add(CalcPoint(7, x, z, wallColors));
            }

            if (mazeMap[x, z].Walls[3])
            {
                triangles.Add(CalcPoint(1, x, z, wallColors));
                triangles.Add(CalcPoint(0, x, z, wallColors));
                triangles.Add(CalcPoint(3, x, z, wallColors));
                triangles.Add(CalcPoint(0, x, z, wallColors));
                triangles.Add(CalcPoint(2, x, z, wallColors));
                triangles.Add(CalcPoint(3, x, z, wallColors));
            }
            return triangles;
        }

        private VertexPositionColor CalcPoint(int wallPoint, int xOffset, int zOffset, Color color)
        {
            return new VertexPositionColor(wallPoints[wallPoint] + new Vector3(xOffset, 0, zOffset), color);
        }
        #endregion

        #region Draw
        public void Draw(Camera camera)
        {
            effect.VertexColorEnabled = true;
            effect.World = Matrix.Identity;
            effect.View = camera.View;
            effect.Projection = camera.Projection;
            foreach (EffectPass pass in effect.CurrentTechnique.Passes)
            {
                pass.Apply();
                device.SetVertexBuffer(vertexBuffer);
                device.DrawPrimitives(PrimitiveType.TriangleList, 0, vertexBuffer.VertexCount / 3);
            }
        }
        #endregion
    }
}
