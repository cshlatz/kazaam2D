using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;

namespace Kazaam.Loaders {
    public class SoundLoader : IContentLoader {
        public ContentManager Content { get; set; }
        public object Load(string contentPath) {
            SoundEffect sound = Content.Load<SoundEffect>(contentPath);
            return sound;
        }
    }
}
