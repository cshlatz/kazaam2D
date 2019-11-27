using Kazaam.Components;
using Kazaam.Display;
using HumperWorld = Humper.World;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Tiled;
using MonoGame.Extended.Tiled.Renderers;
using System.Collections.Generic;

namespace Kazaam.Universe {
    /// <summary>
    /// A representation of the engine world.
    /// </summary>
    public class Map : Objects.IDrawable {
        public TiledMap map;

        private TiledMapRenderer mapRenderer;

        public int width;
        public int height;
        public int tileWidth;
        public int tileHeight;
        public float offsetX;
        public float offsetY;

        public Scene scene;

        // Backgrounds
        public List<Background> Backgrounds { get; set; }

        public Vector2 StartingPosition;

        public HumperWorld HumperWorld {get; set;}

        public Map(TiledMap map, int tileWidth, int tileHeight, GraphicsDevice gd) {
            // Initialize the background list
            Backgrounds = new List<Background>();
            this.map = map;
            this.mapRenderer = new TiledMapRenderer(gd, map);
            width = map.Width * tileWidth;
            height = map.Height * tileHeight;
            this.tileWidth = tileWidth;
            this.tileHeight = tileHeight;
        }

        public void Update(GameTime gameTime) {
            mapRenderer.Update(gameTime);
            foreach (Background bg in Backgrounds) {
                bg.Update(gameTime);
            }
        }

        public void Draw(SpriteBatch sb, Scene scene) {
            var newMatrix = scene.CameraManager.View * Matrix.CreateTranslation((offsetX * scene.CameraManager.Zoom), (offsetY * scene.CameraManager.Zoom), 0);
            sb.Begin(transformMatrix: newMatrix, samplerState: SamplerState.PointClamp); // Draw the map
            mapRenderer.Draw(newMatrix);
            sb.End();
        }

        public void AddBackground(Background bg) {
            Backgrounds.Add(bg);
            var entity = scene.CreateEntity();
            var bgBody = new Body();
            bgBody.Position = new Vector2(0, 0);
            entity.Attach(bgBody);
            entity.Attach(bg);
            entity.Attach(new RenderComponent(bg.Texture));
        }
    } 
}
