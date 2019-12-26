using Kazaam.Components;
using Microsoft.Xna.Framework;

namespace Kazaam.Physics {
    /// <summary>
    /// Enforces a pattern strategy design pattern for processing physics
    /// </summary>
    public interface IPhysicsStrategy {
        void Update(GameTime gameTime);
        GameObject GameObject { get; set; }
        PhysicsBody PhysicsBody { get; set; }
        Hitbox PhysicsTarget { get; set; }
    }
}
