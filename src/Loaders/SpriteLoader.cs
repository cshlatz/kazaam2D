using Microsoft.Xna.Framework.Graphics;

namespace Kazaam.Assets {
  public class SpriteLoader : IContentLoader {
    public object Load(XNAGame game, string contentPath) {
      Texture2D texture = game.Content.Load<Texture2D>(contentPath);
      var sprite = new Sprite(texture);
      return sprite;
    }
  }
}
