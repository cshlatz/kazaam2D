using Microsoft.Xna.Framework.Content;

namespace Kazaam.Assets {
    public interface IContentLoader {
        ContentManager Content { get; set; }
        object Load(string contentPath);
    }
}
