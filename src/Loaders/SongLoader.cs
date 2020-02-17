using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;

namespace Kazaam.Loaders {
    public class SongLoader : IContentLoader {
        public ContentManager Content { get; set; }
        public object Load(string contentPath) {
            Song song = Content.Load<Song>(contentPath);
            return song;
        }
    }
}
