using Humper;
using Kazaam.Physics;
using Microsoft.Xna.Framework;

namespace Kazaam.Components {
    public class Collider : IComponent {
        /// <summary>
        /// The bounds of the collider
        /// </summary>
        public IBox Bounds { get; set; }

        /// <summary>
        /// The position of the collider in the game world
        /// </summary>
        public Vector2 Position { get; set; }

        /// <summary>
        /// The position of the collider relative to it's parent
        /// </summary>
        public Vector2 Offset { get; set; }

        /// <summary>
        /// The script that is run when a collision occurs with this object
        /// </summary>
        public ICollisionStrategy OnCollision { get; set; }
    }
}
