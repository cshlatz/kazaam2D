using Kazaam;
using Kazaam.Maps;
using Microsoft.Xna.Framework.Content;
using MonoGame.Extended.Tiled;

namespace Kazaam.Loaders {
    /// <summary>
    /// A loader that creates Map objects from Tiled map files.
    /// </summary>
    public class MapLoader : IContentLoader {
        public ContentManager Content { get; set; }
        public Map map;
        public TiledMap tiledMap;

        private ITiledStrategy _strategy;

        public ITiledStrategy Strategy {
            get {
                return _strategy;
            }
            set {
                _strategy = value;
            }
        }

        public object Load(string contentPath) {
            tiledMap = Content.Load<TiledMap>(contentPath);
            int tileWidth = tiledMap.TileWidth;
            int tileHeight = tiledMap.TileHeight;
            map = new Map(tiledMap, tileWidth, tileHeight);
            LoadMapContent();
            return map;
        }

        /// <summary>
        /// Loads the tiled map and tileset and creates necessary GameObjects
        /// </summary>
        private void LoadMapContent() {
          if (Strategy == null) {
            Kazaam.XNAGame.Log("MapLoader has no Strategy loaded");
            return;
          }
          foreach (TiledMapObjectLayer objectLayer in tiledMap.ObjectLayers) {
            try {
                map.StartingPosition = objectLayer.Objects[0].Position;
            } catch {

            }
          }
          foreach (TiledMapTileLayer tileLayer in tiledMap.TileLayers) {
            for (ushort x = 0; x < tileLayer.Width; x++) {
              for (ushort y = 0; y < tileLayer.Height; y++) {
                TiledMapTile? tileTry;
                tileLayer.TryGetTile(x, y, out tileTry);
                if (tileTry.HasValue) {
                  TiledMapTile tile = (TiledMapTile) tileTry;
                  if (tile.GlobalIdentifier > 0) {
                    _strategy.Load(map, tileLayer.Name, x, y);
                  }
                }
              }
            }
          }
        }
  }
}
