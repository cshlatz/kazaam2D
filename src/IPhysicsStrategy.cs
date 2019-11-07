using Kazaam.Components;
using Humper;
using Microsoft.Xna.Framework;
using Kazaam.Objects;

namespace Kazaam.Physics {
    /// <summary>
    /// Enforces a pattern strategy design pattern for processing physics
    /// </summary>
    public interface IPhysicsStrategy {
        void Update(GameTime gameTime);
        Body Body { get; set; }
        PhysicsBody PhysicsBody { get; set; }
        Hitbox PhysicsTarget { get; set; }
    }
}
