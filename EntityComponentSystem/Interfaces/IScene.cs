using Microsoft.Xna.Framework;
using System;

namespace EntityComponentSystem
{
    public interface IScene
    {
        void Initialize();

        void Update(GameTime gameTime);

        void Draw(GameTime gameTime);

    }
}
