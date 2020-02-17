using Humper;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Kazaam.Components {
    public class Collider : IComponent {
        /// <summary>
        /// A list that contains all bounds of this entity.
        /// </summary>
        public List<IBox> Bounds { get; set; }

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
