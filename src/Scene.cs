using HumperWorld = Humper.World;

using Kazaam.Objects;
using Kazaam.Universe;
using Kazaam.View;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;

using MonoGame.Extended;
using MonoGame.Extended.Entities;
using SceneWorld = MonoGame.Extended.Entities.World;
using MonoGame.Extended.ViewportAdapters;

using System.Collections;

namespace Kazaam {
  
  /// <summary>
  /// A collection of Kazaam.Universe objects that define a world in the engine.
  /// </summary>
  public class Scene { 
		public XNAGame game;

		// Scene Objects
		public HumperWorld hworld;
    public SceneWorld sworld;
    public Map _map;
    public GameObjectFactory Factory { get; set; } 
		public ArrayList _objects = new ArrayList();

		public float Gravity { get; }
    public Vector2 Vec { get; set; }

    // Camera
    public int CameraId {get; set;}
    public Matrix CameraMatrix {get; set;}
    public Body CameraFocus {get; set;}

		public Scene(XNAGame game, SceneWorld world) {
			this.game = game;
      this.sworld = world;
      
      hworld = new HumperWorld(120 * 32, 120 * 32);

      // Camera
      SetupCamera();
		}

    /// <summary>
    /// Plays a background track, ending any currently active song
    /// </summary>
    public void PlayBackgroundTrack(Song song) {
      MediaPlayer.Play(song);
    }

    /// <summary>
    /// Pauses the current background track, with progress saved
    /// </summary>
    public void PauseBackgroundTrack() {
      MediaPlayer.Pause();
    }
    
    public void AddEntity(System.Collections.Generic.List<object> list) {
      var entity = sworld.CreateEntity();
      foreach (var component in list) {
        entity.Attach(component);
      }
      return;
    }

    private void SetupCamera() {
      var cameraEntity = sworld.CreateEntity();
      var viewportAdapter = new BoxingViewportAdapter(game.Window, game.GraphicsDevice, (int)game.Resolution.X, (int)game.Resolution.Y);
      var cameraComponent = new CameraComponent();
      cameraComponent.InternalCamera = new OrthographicCamera(viewportAdapter);
      cameraComponent.CameraFocus = CameraFocus;
      cameraEntity.Attach(new Body());
      cameraEntity.Attach(cameraComponent);
      CameraId = cameraEntity.Id;
    }

    public void SetCameraFocus(Body body) {
      var cameraEntity = sworld.GetEntity(CameraId);
      var cameraComponent = cameraEntity.Get<CameraComponent>();
      cameraComponent.CameraFocus = body;
    }

  }
}

