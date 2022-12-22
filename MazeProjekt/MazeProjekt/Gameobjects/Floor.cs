using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGame
{
    //Creates a white and Gray Tilled Floor
    public class Floor : IMesh
    {
        public Maze maze;
        public GraphicsDevice device;
        public VertexBuffer vertexBuffer;
        private BasicEffect effect;
        Color[] floorColors = new Color[2] { Color.White, Color.Gray };
        public GraphicsDevice Device { get { return device; } set { device = value; } }
        public VertexBuffer VertexBuffer { get { return vertexBuffer; } set { vertexBuffer = value; } }
        public BasicEffect Effect { get { return effect; } set { effect = value; } }
        public Floor(Maze maze)
        {
            this.maze = maze;
            this.device = maze.game.GraphicsDevice;
            effect = new BasicEffect(device) { VertexColorEnabled = true };
            CreateBuffer();
        }
        public void CreateBuffer()
        {
            List<VertexPositionColor> vertexList = new List<VertexPositionColor>();
            int counter = 0;
            for (int x = 0; x < Maze.Height; x++)
            {
                counter++;
                for (int z = 0; z < Maze.Width; z++)
                {
                    counter++;
                    foreach (VertexPositionColor vertex in CreatePolys(0, x, z, floorColors[counter % 2]))
                    {
                        vertexList.Add(vertex);
                    }
                }
            }
            vertexBuffer = new VertexBuffer(device, VertexPositionColor.VertexDeclaration, vertexList.Count, BufferUsage.WriteOnly);
            vertexBuffer.SetData<VertexPositionColor>(vertexList.ToArray());
        }

        public List<VertexPositionColor> CreatePolys(int point, int x, int z, Color color)
        {
            List<VertexPositionColor> vList = new List<VertexPositionColor>();

            vList.Add(new VertexPositionColor(new Vector3(0 + x, 0, 0 + z), color));
            vList.Add(new VertexPositionColor(new Vector3(1 + x, 0, 0 + z), color));
            vList.Add(new VertexPositionColor(new Vector3(0 + x, 0, 1 + z), color));

            vList.Add(new VertexPositionColor(new Vector3(1 + x, 0, 0 + z), color));
            vList.Add(new VertexPositionColor(new Vector3(1 + x, 0, 1 + z), color));
            vList.Add(new VertexPositionColor(new Vector3(0 + x, 0, 1 + z), color));

            return vList;
        }

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
    }
}
