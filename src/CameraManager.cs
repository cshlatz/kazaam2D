using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Kazaam.View {
    public interface ICamera {
        void Update(GameTime gameTime);
        Matrix View {get;}
        float Zoom {get; set;}
    }

    public class CameraManager {
        private Dictionary<string, Camera> cameras = new Dictionary<string, Camera>();
        private Camera currentCamera;

        public void RegisterCamera(string id, Camera camera) {
            cameras[id] = camera;
        }

        public void SetCamera(string id) {
            currentCamera = cameras[id];
        }

        public void Update(GameTime gameTime) {
            currentCamera.Update(gameTime);
        }

        public Matrix View {
            get {
                return currentCamera.View;
            }
        }

        public Viewport Viewport {
            get {
                return currentCamera.Viewport;
            }
        }

        public float Zoom {
            get {
                return currentCamera.Zoom;
            }
            set {
                currentCamera.Zoom = value;
            }
        }

        public Vector2 Position {
            get {
                return currentCamera.Position;
            }
        }
    }
}
