using Microsoft.Xna.Framework;

namespace EntityComponentSystem
{
    public interface IComponent
    {
        bool Enabled { get; set; }
        void Update(GameTime gameTime);
    }
}
