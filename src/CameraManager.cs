using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Kazaam.View {
    public interface ICamera {
        void Update(GameTime gameTime);
        Matrix View {get;}
        float Zoom {get; set;}
    }

    public class CameraManager {
        private Dictionary<string, ICamera> cameras = new Dictionary<string, ICamera>();
        private ICamera currentCamera;

        public void RegisterCamera(string id, ICamera camera) {
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

        public float Zoom {
            get {
                return currentCamera.Zoom;
            }
            set {
                currentCamera.Zoom = value;
            }
        }
    }
}
