using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;

namespace Kazaam.Assets {
    /// <summary>
    /// A collection of IContentLoader implementations that can load individual assets to the engine that have been built with the monogame pipeline.
    /// </summary>
    public class ContentLoader {
        ContentManager Content;
        Dictionary<string, IContentLoader> loaders = new Dictionary<string, IContentLoader>();

        public ContentLoader(ContentManager Content) {
            this.Content = Content;
        }

        public object LoadContent(string type, string name) {
            var loader = loaders[type];
            try {
                return loader.Load(name);
            } catch (ContentLoadException e) {
                XNAGame.Log(e.ToString());
                return null;
            }
        }

        public void RegisterType(string key, IContentLoader loader) {
            loader.Content = Content;
            loaders[key] = loader;
        }

    }
}
