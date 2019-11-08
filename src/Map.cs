using Kazaam.Display;
using HumperWorld = Humper.World;
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
      public TiledMap map;

      private TiledMapRenderer mapRenderer;

      public int width;
      public int height;
      public int tileWidth;
      public int tileHeight;
      public float offsetX;
      public float offsetY;

      public Scene scene;

      public Background Background { get; set; }

      public Vector2 StartingPosition;

      public HumperWorld HumperWorld {get; set;}

      public Map(TiledMap map, int tileWidth, int tileHeight, GraphicsDevice gd) {
        this.map = map;
        this.mapRenderer = new TiledMapRenderer(gd, map);
        width = map.Width * tileWidth;
        height = map.Height * tileHeight;
        this.tileWidth = tileWidth;
        this.tileHeight = tileHeight;
        //background = this.scene.game.Content.Load<Texture2D>("resources/bin/maps/surface/bg1");
      }

      public void Update(GameTime gameTime) {
        mapRenderer.Update(gameTime);
        Background.Update(gameTime, new Vector2(100, 0));
      }

      public void Draw(SpriteBatch sb, Scene scene) {
        var newMatrix = scene.CameraManager.View * Matrix.CreateTranslation((offsetX * scene.CameraManager.Zoom), (offsetY * scene.CameraManager.Zoom), 0);

        // Draw background
        if (Background != null) {
            sb.Begin(samplerState: SamplerState.LinearWrap); // Draw the background
            sb.Draw(Background.Texture, new Vector2(scene.CameraManager.Viewport.X, scene.CameraManager.Viewport.Y), Background.Rectangle(scene.CameraManager.Viewport), Color.White, 0, Vector2.Zero, Background.Zoom, SpriteEffects.None, 1);
            sb.End();
        }

        // SamplerState.PointClamp prevents gaps between the tiles while rendering
        sb.Begin(transformMatrix: newMatrix, samplerState: SamplerState.PointClamp); // Draw the map
        mapRenderer.Draw(newMatrix);
        sb.End();
      }
    } 
}
