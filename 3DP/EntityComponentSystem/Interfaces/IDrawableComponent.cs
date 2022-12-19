using Microsoft.Xna.Framework;

namespace EntityComponentSystem
{
    public interface IDrawableComponent : IComponent
    {
        void Draw(Camera currentCamera, GameTime gameTime);
    }
}
