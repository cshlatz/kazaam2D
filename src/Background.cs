using Kazaam.Assets;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Kazaam.Display {

    public class Background {
        public Sprite Texture { get; private set; }
        public Vector2 Offset { get; private set; }
        public Vector2 Speed { get; set; }
        public Vector2 Direction { get; set; }
        public float Zoom { get; set; }
        public float LayerDepth { get; set; }
 
        private Viewport _viewport;

        public Rectangle Rectangle(Viewport viewport) {
            return new Rectangle((int)(Offset.X), (int)(Offset.Y), (int)(viewport.Width / Zoom), (int)(viewport.Height / Zoom));
        }

        public Background(Sprite texture, Vector2 speed, float zoom)
        {
            Texture = texture;
            Offset = Vector2.Zero;
            Speed = speed;
            Zoom = zoom;
        }
 
        public void Update(GameTime gametime)
        {
            float elapsed = (float)gametime.ElapsedGameTime.TotalSeconds;
 
            //Calculate the distance to move our image, based on speed
            Vector2 distance = Direction * Speed * elapsed;

            //Update our offset
            Offset += distance;
        }
    }
}
