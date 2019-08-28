using Humper;

using Kazaam.Objects;
using Kazaam.Universe;
using Kazaam.View;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using MonoGame.Extended;
using MonoGame.Extended.ViewportAdapters
;

using System.Collections;

namespace Kazaam {
  
  /// <summary>
  /// A collection of Kazaam.Universe objects that define a world in the engine.
  /// </summary>
  public class Scene { 
    public enum Type {
      Platformer,
      TopDown,
      Menu
    }

		public XNAGame game;

    public Type SceneType;

		// Scene Objects
		public World world;
    public Map _map;
    public Camera mainCamera;
		public ArrayList _objects = new ArrayList();

		public float Gravity { get; }
    public Vector2 Vec { get; set; }


		public Scene(XNAGame game) {
			this.game = game;

      // Setup the tiled world
			world = new World(120 * 32, 120 * 32);

      // Scene type
		  SceneType = Type.Platformer;	

      // World physics
			Gravity = 9.8f;

      // Camera
      mainCamera = new Camera(game);
		}

    public void SetCameraFocus(PhysicsObject focus) {
      mainCamera.CameraFocus = focus;
    }

		public ArrayList SceneObjects() {
			return _objects;
		}
  }

}

