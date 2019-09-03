using Kazaam.Objects;
using Kazaam.Universe;
using Microsoft.Xna.Framework;
using MonoGame.Extended.Tiled;
using MonoGame.Extended.Tiled.Renderers;

namespace Kazaam.Assets
{

    /// <summary>
    /// A loader that creates Map objects from Tiled map files.
    /// </summary>
    public class MapLoader : IContentLoader {
    public Map map;
    public TiledMap tiledMap;
    
    private XNAGame game;

    public void SetGame(XNAGame game) {
      this.game = game;
    }

    public object Load(XNAGame game, string contentPath) {
      this.game = game;
      tiledMap = game.Content.Load<TiledMap>(contentPath);
      int tileWidth = tiledMap.TileWidth;
      int tileHeight = tiledMap.TileHeight;
      map = new Map(tiledMap, tileWidth, tileHeight, game.GraphicsDevice);
      map.scene = game.scene;
      LoadMapContent();
      return map;
    }

    /// <summary>
    /// Loads the tiled map and tileset and creates necessary GameObjects
    /// </summary>
    private void LoadMapContent() {
      foreach (TiledMapObjectLayer objectLayer in tiledMap.ObjectLayers) {
        map.StartingPosition = objectLayer.Objects[0].Position;
      }
      foreach (TiledMapTileLayer tileLayer in tiledMap.TileLayers) {
        for (ushort x = 0; x < tileLayer.Width; x++) {
          for (ushort y = 0; y < tileLayer.Height; y++) {
            TiledMapTile? tileTry;
            tileLayer.TryGetTile(x, y, out tileTry);
            if (tileTry.HasValue) {
              TiledMapTile tile = (TiledMapTile) tileTry;
              if (tile.GlobalIdentifier > 0) {
                // Create platforms
                switch (tileLayer.Name) {
                  // TODO: Get rid of these hardcoded strings
                  case "Platform":
                    var body = new Body();
                    body.Dimensions = new Vector2(map.tileWidth, map.tileHeight);
                    body.Position = new Vector2(map.tileWidth * x, map.tileHeight * y);
                    body.Bounds.AddTags(Enums.Tags.Platforms);
                    game.scene.factory.CreateGameObject(body);
                    break;
                }
              }
            }
          }
        }
      }
    }
  }
}
