using Microsoft.Xna.Framework.Media;

namespace Kazaam.Assets {
  public class SongLoader : IContentLoader {
    public object Load(XNAGame game, string contentPath) {
      Song song = game.Content.Load<Song>(contentPath);
      return song;
    }
  }
}
