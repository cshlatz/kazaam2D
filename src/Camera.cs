using Kazaam;
using Kazaam.Components;
using Kazaam.View;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using MonoGame.Extended.ViewportAdapters;

namespace Kazaam.View {
    public abstract class Camera : ICamera {
        protected readonly OrthographicCamera _internalCamera;
        protected readonly XNAGame game;

        private Body _cameraFocus;
        private float _zoom;

        private readonly int _viewportWidth;
        private readonly int _viewportHeight;

        public Body CameraFocus {
            get {
                return _cameraFocus;
            }
            set {
                _cameraFocus = value;
            }
        }

       public float Zoom {
            get {
                return _zoom;
            }
            set {
                _zoom = value;
                _internalCamera.Zoom = _zoom;
            }
        }

        public Camera(XNAGame game) {
            this.game = game;
            _viewportWidth = game.Graphics.Viewport.Width;
            _viewportHeight = game.Graphics.Viewport.Height;
            var viewportAdapter = new BoxingViewportAdapter(game.Window, game.GraphicsDevice, game.GameWindow.XResolution, game.GameWindow.YResolution);
            _internalCamera = new OrthographicCamera(viewportAdapter);
        }

        public Matrix View {
            get {
                return Matrix.CreateTranslation(
                           - _internalCamera.Position.X,
                           - _internalCamera.Position.Y,
                           0) *
                       Matrix.CreateScale(
                           new Vector3(Zoom, Zoom, 1)) *
                       Matrix.CreateTranslation(
                           new Vector3(_viewportWidth * 0.5f, _viewportHeight * 0.5f, 0));

            }
        }

        public Vector2 CameraClamp(Vector2 position) {
            var cameraMax = new Vector2(game.scene.Map.width - (_viewportWidth / Zoom / 2), game.scene.Map.height - (_viewportHeight / Zoom / 2));
            return Vector2.Clamp(position,
                                 new Vector2(_viewportWidth / Zoom / 2, _viewportHeight / Zoom / 2),
                                 cameraMax);
        }

        public Viewport Viewport {
            get {
                return game.Graphics.Viewport;
            }
        }

        public abstract void Update(GameTime gameTime);

    }
}
