using Kazaam.Components;
using Kazaam.Display;
using HumperWorld = Humper.World;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Tiled;
using MonoGame.Extended.Tiled.Renderers;
using System.Collections.Generic;

namespace Kazaam {
    /// <summary>
    /// A representation of the engine world.
    /// </summary>
    public class Map {
        public TiledMap map;

        private float _width;
        private float _height;
        private float _tileWidth;
        private float _tileHeight;

        private TiledMapRenderer _renderer;
        private Scene _scene;
        public Scene Scene {
            get {
                return _scene;
            }
            set {
                _scene = value;
                _renderer = new TiledMapRenderer(_scene.Graphics, this.map);
            }
        }

        /// <summary>
        /// The width of the map in pixels. This takes into account the zoom and virtual resolution of the game.
        /// The width of the map in game units is represented by the private _width field
        /// </summary>
        public float Width {
            get {
                return _width * Scene.ResolutionScale.X;
            }
            set {
                _width = value;
            }
        }

        public float Height {
            get {
                return _height * Scene.ResolutionScale.Y;
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

        public float offsetX;
        public float offsetY;

        // Backgrounds
        public List<Background> Backgrounds { get; set; }

        public Vector2 StartingPosition;

        public HumperWorld HumperWorld {get; set;}

        public Map(TiledMap map, int tileWidth, int tileHeight) {
            // Initialize the background list
            Backgrounds = new List<Background>();
            this.map = map;
            _width = map.Width * tileWidth;
            _height = map.Height * tileHeight;
            _tileWidth = tileWidth;
            _tileHeight = tileHeight;
        }

        public void Update(GameTime gameTime) {
            _renderer.Update(gameTime);
            foreach (Background bg in Backgrounds) {
                bg.Update(gameTime);
                bg.Speed = Scene.CameraManager.Speed * bg.ParallaxFactor;
                bg.Speed = bg.Speed + bg.ConstantSpeed;
            }
        }

        public void AddBackground(Background bg) {
            Backgrounds.Add(bg);
            var entity = Scene.CreateEntity();
            var bgBody = new GameObject();
            bgBody.Position = new Vector2(0, 0);
            entity.Attach(bgBody);
            entity.Attach(bg);
            entity.Attach(new Renderer(bg.Texture));
        }

        public void Draw(GameTime gameTime) {
            var newMatrix = Scene.CameraManager.View; //* Matrix.CreateTranslation((offsetX * Scene.CameraManager.Zoom), (offsetY * Scene.CameraManager.Zoom), 0);
            Scene.XNAWindow.spriteBatch.Begin(samplerState: SamplerState.LinearWrap); // Draw the map
            foreach (Background bg in Backgrounds) {
                Scene.XNAWindow.spriteBatch.Draw(bg.Texture.Texture, new Rectangle(0, 0, Scene.CameraManager.Viewport.Width, Scene.CameraManager.Viewport.Height), bg.Rectangle(Scene.CameraManager.Viewport), Color.White);
            }
            Scene.XNAWindow.spriteBatch.End();
            Scene.XNAWindow.spriteBatch.Begin(transformMatrix: newMatrix, samplerState: SamplerState.PointClamp); // Draw the map
            _renderer.Draw(newMatrix);
            Scene.XNAWindow.spriteBatch.End();
        }

    }
}
