using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework.Content;

namespace Kazaam.Loaders {

    /// <summary>
    /// An interface for dedicated streams meant to load a file into a specific Kazaam object type.
    /// </summary>
    public interface IAssetStreamProvider {
        Stream GetStream(string type, string name);
    }

    /// <summary>
    /// A collection of ITypeLoader implementations that can load individual assets to the engine.
    /// </summary>
    public class AssetLoader {
        Dictionary<string, ITypeLoader> loaders = new Dictionary<string, ITypeLoader>();
        IAssetStreamProvider provider;

        public AssetLoader(IAssetStreamProvider streamProvider) {
            provider = streamProvider;
        }

        public object LoadAsset(string type, string name) {
            try {
                var loader = loaders[type];
                var stream = provider.GetStream(type, name);
                return loader.Load(stream);
            } catch (ContentLoadException e) {
                XNAGame.Log(e.ToString());
                return null;
            }
        }

        public void RegisterType(string key, ITypeLoader loader) {
            loaders[key] = loader;
        }

    }
}
