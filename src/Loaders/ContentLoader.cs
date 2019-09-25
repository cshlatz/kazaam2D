using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;

namespace Kazaam.Assets {
  /// <summary>
  /// A collection of IContentLoader implementations that can load individual assets to the engine that have been built with the monogame pipeline.
  /// </summary>
  public class ContentLoader {

    public XNAGame Game {get; set;}

    Dictionary<string, IContentLoader> loaders = new Dictionary<string, IContentLoader>();

    public ContentLoader(XNAGame game) {
      Game = game;
    }

    public object LoadContent(string type, string name) {
      var loader = loaders[type];
      try {
        return loader.Load(Game, name);
      } catch (ContentLoadException e) {
        XNAGame.Log(e.ToString());
        return null;
      }
    }

    public void RegisterType(string key, IContentLoader loader) {
      loaders[key] = loader;
    }

  }
}
