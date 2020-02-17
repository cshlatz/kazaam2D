using Kazaam.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Kazaam.Loaders {
    public class SpriteLoader : IContentLoader {
        public ContentManager Content { get; set; }
        public object Load(string contentPath) {
            Texture2D texture = Content.Load<Texture2D>(contentPath);
            var sprite = new Sprite(texture);
            return sprite;
        }
    }
}
