using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Kazaam.View {
    public interface ICamera {
        void Update(float dt);
        Matrix View {get;}
        int Zoom {get; set;}
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

        public void Update(float dt) {
            currentCamera.Update(dt);
        }

        public Matrix View {
            get {
                return currentCamera.View;
            }
        }

        public int Zoom {
            get {
                return currentCamera.Zoom;
            }
            set {
                currentCamera.Zoom = value;
            }
        }
    }
}
