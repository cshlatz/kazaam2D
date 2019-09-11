using Kazaam.Objects;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Tiled;
using MonoGame.Extended.Tiled.Renderers;

namespace Kazaam.Universe
{
    /// <summary>
    /// A representation of the engine world.
    /// </summary>
    public class Map : Objects.IDrawable
    {
        private TiledMap map;

      private TiledMapRenderer mapRenderer;

      public int tileWidth;
      public int tileHeight;

      public Scene scene;

      public Texture2D background;

      public Vector2 StartingPosition;

      public Map(TiledMap map, int tileWidth, int tileHeight, GraphicsDevice gd) {
        this.map = map;
        this.mapRenderer = new TiledMapRenderer(gd, map);
        this.tileWidth = tileWidth;
        this.tileHeight = tileHeight;
        //background = this.scene.game.Content.Load<Texture2D>("resources/bin/maps/surface/bg1");
      }

      public void Update(GameTime gameTime) {
        mapRenderer.Update(gameTime);
      }

      public void Draw(SpriteBatch sb, Scene scene) {
        // SamplerState.PointClamp prevents gaps between the tiles while rendering
        sb.Begin(samplerState: SamplerState.PointClamp);
        //sb.Draw(background, new Rectangle(0, 0, (int)scene.game.Resolution.X, (int)scene.game.Resolution.Y), Color.White);
        sb.End();
        sb.Begin(transformMatrix: scene.CameraMatrix, samplerState: SamplerState.PointClamp);
        mapRenderer.Draw(scene.CameraMatrix);
        sb.End();
      }
    } 
}
