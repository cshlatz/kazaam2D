using Kazaam.Components;
using Humper;

namespace Kazaam {
    public class GameWorld {
        World World { get; set; }

        public GameWorld(int width, int height) {
            World = new World(width, height);
        }

        public Hitbox Create(GameObject gameObject, int x, int y, int width, int height) {
            var hitbox = new Hitbox(x, y, width, height);
            hitbox.Parent = gameObject;
            hitbox.Bounds = World.Create(x, y, hitbox.Width, hitbox.Height);
            return hitbox;
        }
    }
}
