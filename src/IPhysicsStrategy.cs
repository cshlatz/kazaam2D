using Kazaam.Objects;
using Microsoft.Xna.Framework;

namespace Kazaam.Universe {
    /// <summary>
    /// Enforces a pattern strategy design pattern for processing physics
    /// </summary>
    public interface IPhysicsStrategy {
        void Update(GameTime gameTime);
        Body PhysicsBody {get; set;}
    }
}
