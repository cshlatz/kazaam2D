using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

namespace Kazaam.Assets {
  public class SoundLoader : IContentLoader {
    public object Load(XNAGame game, string contentPath) {
      Song sound = game.Content.Load<Song>(contentPath);
      return sound;
    }
  }
}
