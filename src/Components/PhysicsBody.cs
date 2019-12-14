using Kazaam.Physics;
using Microsoft.Xna.Framework;

namespace Kazaam.Components {
    public class PhysicsBody {
        /// <summary>
        /// A user defined script for how this object is affected by physics
        /// </summary>
        public IPhysicsStrategy PhysicsStrategy { get; set; }

        /// <summary>
        /// The speed of the physics body in the game world
        /// </summary>
        public Vector2 Velocity { get; set; }

        /// <summary>
        /// A flag for whether or not the physics object is in a grounded state
        /// </summary>
        public bool Grounded { get; set; }

        /// <summary>
        /// A user defined script for how this object is affected by physics
        /// </summary>
        public ICollisionStrategy CollisionStrategy { get; set; }
  }
}
