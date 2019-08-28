
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Tiled;
using MonoGame.Extended.Tiled.Graphics;

namespace Kazaam.Universe
{

    /// <summary>
    /// A representation of the engine world.
    /// </summary>
    public class Map {
    private TiledMap map;

    private TiledMapRenderer mapRenderer;

    public int tileWidth;
    public int tileHeight;

    public Scene scene;

    public Texture2D background;

    public Vector2 StartingPosition;

    public Map(TiledMap map, TiledMapRenderer mapRenderer, int tileWidth, int tileHeight) {
      this.map = map;
      this.mapRenderer = mapRenderer;
      this.tileWidth = tileWidth;
      this.tileHeight = tileHeight;
      //background = this.scene.game.Content.Load<Texture2D>("resources/bin/maps/surface/bg1");
    }

    public void Update(GameTime gameTime) {
      mapRenderer.Update(this.map, gameTime);
    }

    public void Draw(SpriteBatch sb) {
      // SamplerState.PointClamp prevents gaps between the tiles while rendering
      sb.Begin(samplerState: SamplerState.PointClamp);
      //sb.Draw(background, new Rectangle(0, 0, (int)scene.game.Resolution.X, (int)scene.game.Resolution.Y), Color.White);

      sb.End();
            sb.Begin(transformMatrix: scene.mainCamera.GetViewMatrix(), samplerState: SamplerState.PointClamp);
      mapRenderer.Draw(this.map, scene.mainCamera.GetViewMatrix());
      sb.End();
    }
  }
}
