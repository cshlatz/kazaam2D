using Kazaam.Components;
using Humper;

namespace Kazaam.System {
    public class GameWorld {
        World World { get; set; }

        public GameWorld(int width, int height) {
            World = new World(width, height);
        }

        public Hitbox Create(Body body, int x, int y, int width, int height) {
            var hitbox = new Hitbox(x, y, width, height);
            hitbox.Parent = body;
            body.Hitboxes.Add(hitbox);
            hitbox.Bounds = World.Create(x, y, hitbox.Width, hitbox.Height);
            return hitbox;
        }
    }
}
