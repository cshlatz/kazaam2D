using Kazaam.Enums;

using Humper;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Kazaam.Objects {
  /// <summary>
  /// An invisible bound attached to a GameObject that can act as a special collision point between other Hitbox objects.
  /// </summary>
  public class Hitbox {
    public IBox Bounds;
    private Body body;
    private Texture2D hitbox;
    public Vector2 Position; // Position relative to top left corner of gameobject parent
    public Hitbox(World world, Body body, Vector2 position, float width, float height, Tags tag) {
      Position = position;
      this.body = body;
      Bounds = world.Create(body.Position.X + Position.X, body.Position.Y + Position.Y, width, height).AddTags(tag);
    }

    public void Draw(SpriteBatch sb, Scene scene) {
      hitbox = new Texture2D(scene.Game.GraphicsDevice, (int)Bounds.Width, (int)Bounds.Height);
      Color[] data = new Color[hitbox.Width * hitbox.Height];
      for (int i = 0; i < data.Length; i++) {
        data[i] = Color.Red;
      }
      hitbox.SetData(data);
      sb.Draw(hitbox, new Vector2(Bounds.X, Bounds.Y));
    }
  }
}
