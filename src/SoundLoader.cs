using Microsoft.Xna.Framework.Audio;

namespace Kazaam.Assets {
  public class SoundLoader : IContentLoader {
    public object Load(XNAGame game, string contentPath) {
      SoundEffect sound = game.Content.Load<SoundEffect>(contentPath);
      return sound;
    }
  }
}
