using Microsoft.Xna.Framework.Content;

namespace Kazaam.Loaders {
    public interface IContentLoader {
        ContentManager Content { get; set; }
        object Load(string contentPath);
    }
}
