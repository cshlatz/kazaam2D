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
        public Scene scene;

        private float _width;
        private float _height;
        private float _tileWidth;
        private float _tileHeight;


        /// <summary>
        /// The width of the map in pixels. This takes into account the zoom and virtual resolution of the game.
        /// The width of the map in game units is represented by the private _width field
        /// </summary>
        public float Width {
            get {
                return _width * scene.Game.GameWindow.ResolutionScale.X;
            }
            set {
                _width = value;
            }
        }

        public float Height {
            get {
                return _height * scene.Game.GameWindow.ResolutionScale.Y;
            }
            set {
                _height = value;
            }
        }

        public float TileWidth {
            get {
                return _tileWidth;
            }
            set {
                _tileWidth = value;
            }
        }

        public float TileHeight {
            get {
                return _tileHeight;
            }
            set {
                _tileHeight = value;
            }
        }

        private TiledMapRenderer _mapRenderer;

        public float offsetX;
        public float offsetY;


        // Backgrounds
        public List<Background> Backgrounds { get; set; }

        public Vector2 StartingPosition;

        public HumperWorld HumperWorld {get; set;}

        public Map(TiledMap map, int tileWidth, int tileHeight, GraphicsDevice gd) {
            // Initialize the background list
            Backgrounds = new List<Background>();
            this.map = map;
            _mapRenderer = new TiledMapRenderer(gd, map);
            _width = map.Width * tileWidth;
            _height = map.Height * tileHeight;
            _tileWidth = tileWidth;
            _tileHeight = tileHeight;
        }

        public void Update(GameTime gameTime) {
            _mapRenderer.Update(gameTime);
            foreach (Background bg in Backgrounds) {
                bg.Update(gameTime);
                bg.Speed = scene.CameraManager.Speed * bg.ParallaxFactor;
            }
        }

        public void Draw(SpriteBatch sb, Scene scene) {
            var newMatrix = scene.CameraManager.View * Matrix.CreateTranslation((offsetX * scene.CameraManager.Zoom), (offsetY * scene.CameraManager.Zoom), 0);
            sb.Begin(samplerState: SamplerState.LinearWrap); // Draw the map
            foreach (Background bg in Backgrounds) {
                sb.Draw(bg.Texture.Texture, new Rectangle(0, 0, scene.CameraManager.Viewport.Width, scene.CameraManager.Viewport.Height), bg.Rectangle(scene.CameraManager.Viewport), Color.White);
            }
            sb.End();
            sb.Begin(transformMatrix: newMatrix, samplerState: SamplerState.PointClamp); // Draw the map
            _mapRenderer.Draw(newMatrix);
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
