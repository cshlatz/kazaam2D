using Kazaam.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using MonoGame.Extended.ViewportAdapters;
using System;

namespace Kazaam.Camera {
    public abstract class Camera : ICamera {
        protected readonly OrthographicCamera _internalCamera;
        protected readonly Scene scene;

        private GameObject _cameraFocus;
        private float _zoom;

        private readonly int _viewportWidth;
        private readonly int _viewportHeight;

        private bool _clampToMap;
        private Vector2 _clampRange;

        private Vector2 _speed;

        public bool ClampToMap {
            get {
                return _clampToMap;
            }
            set {
                _clampToMap = value;
            }
        }

        public Vector2 CameraClampRange {
            get {
                return _clampRange;
            }
            set {
                _clampRange = value;
            }
        }

        public GameObject CameraFocus {
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

        public Camera(Scene scene) {
            this.scene = scene;
            _viewportWidth = scene.Graphics.Viewport.Width;
            _viewportHeight = scene.Graphics.Viewport.Height;
            var viewportAdapter = new BoxingViewportAdapter(scene.XNAWindow.Window, scene.Graphics, scene.XNAWindow.XResolution, scene.XNAWindow.YResolution);
            _internalCamera = new OrthographicCamera(viewportAdapter);
        }

        public Matrix View {
            get {
                return
                        Matrix.CreateTranslation(
                           - _internalCamera.Position.X,
                           - _internalCamera.Position.Y,
                           0) *
                       Matrix.CreateScale(
                           new Vector3(Zoom, Zoom, 1)) *
                       Matrix.CreateTranslation(
                           new Vector3(scene.XNAWindow.XResolution * 0.5f, scene.XNAWindow.YResolution * 0.5f, 0)) *
                       Matrix.CreateScale(new Vector3(scene.XNAWindow.ResolutionScale.X, scene.XNAWindow.ResolutionScale.Y, 1.0f));

            }
        }

        /// <summary>
        /// Clamps the camera to a specified range. If the ClampToMap field is set, the range will be dimensions of the active map.
        /// Otherwise, it will use the Vector2 CameraClampRange. If CameraClampRange is not set, it will be unbounded.
        /// </summary>
        public Vector2 CameraClamp(Vector2 position) {
            // If the clamp variables aren't set, literally have the clamp value be unbounded.
            var cameraMax = new Vector2(Int32.MaxValue, Int32.MaxValue);
            if (_clampToMap) {
                cameraMax = new Vector2(scene.Map.Width - (_viewportWidth / Zoom / 2), scene.Map.Height - (_viewportHeight / Zoom / 2));
            }
            if (!_clampToMap && !_clampRange.IsNaN()) {
                cameraMax = new Vector2(_clampRange.X / Zoom / 2, _clampRange.Y / Zoom / 2);
            }
            return Vector2.Clamp(position,
                                 new Vector2(_viewportWidth / Zoom / 2, _viewportHeight / Zoom / 2),
                                 cameraMax);
        }

        public Viewport Viewport {
            get {
                return scene.Graphics.Viewport;
            }
        }

        public Vector2 Position {
            get {
                return _internalCamera.Position;
            }
        }

        public Vector2 Speed {
            get {
                return _speed;
            }
            set {
                _speed = value;
            }
        }

        public abstract void Update(GameTime gameTime);

    }
}
