using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeProjekt
{
    public interface IMesh
    {
        GraphicsDevice Device { get; set; }
        VertexBuffer VertexBuffer { get; set; }
        BasicEffect Effect { get; set; }
        void CreateBuffer();
        List<VertexPositionColor> CreatePolys(int point, int x, int z, Color color);
        void Draw(Camera camera);
    }
}
