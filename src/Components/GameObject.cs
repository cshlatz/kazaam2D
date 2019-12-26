using Microsoft.Xna.Framework;

namespace Kazaam.Components {
    public class GameObject : IComponent {
        public Vector2 Position { get; set; }
        public Vector2 Rotation { get; set; }
        public float Scale { get; set; }
    }
}
