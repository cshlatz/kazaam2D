using HumperWorld = Humper.World;
using Kazaam.Objects;
using Kazaam.Universe;
using Kazaam.View;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework;
using MonoGame.Extended.Entities;
using MonoGame.Extended.ViewportAdapters;
using MonoGame.Extended;
using SceneWorld = MonoGame.Extended.Entities.World;

namespace Kazaam {
  
  /// <summary>
  /// A collection of Kazaam.Universe objects that define a world in the engine.
  /// </summary>
  public class Scene { 
		public readonly XNAGame Game;

    // Scene structures
		public HumperWorld HumperWorld {get; set;}
    public SceneWorld SceneWorld {get; set;}
    public Map Map {get; set;}

    // Camera
    public int CameraId {get; set;}
    public Matrix CameraMatrix {get; set;}
    public Body CameraFocus {get; set;}

		public Scene(XNAGame game, SceneWorld world) {
			this.Game = game;
      this.SceneWorld = world;
      
      HumperWorld = new HumperWorld(120 * 32, 120 * 32);

      // Camera
      SetupCamera();
		}

    /// <summary>
    /// Plays a background track, ending any currently active song
    /// </summary>
    public static void PlayBackgroundTrack(Song song) {
      MediaPlayer.Play(song);
    }

    /// <summary>
    /// Pauses the current background track, with progress saved
    /// </summary>
    public static void PauseBackgroundTrack() {
      MediaPlayer.Pause();
    }

    private void SetupCamera() {
      var cameraEntity = SceneWorld.CreateEntity();
      var viewportAdapter = new BoxingViewportAdapter(Game.Window, Game.GraphicsDevice, (int)Game.Resolution.X, (int)Game.Resolution.Y);
      var cameraComponent = new CameraComponent();
      cameraComponent.InternalCamera = new OrthographicCamera(viewportAdapter);
      cameraComponent.CameraFocus = CameraFocus;
      cameraEntity.Attach(new Body());
      cameraEntity.Attach(cameraComponent);
      CameraId = cameraEntity.Id;
    }

    public void SetCameraFocus(Body body) {
      var cameraEntity = SceneWorld.GetEntity(CameraId);
      var cameraComponent = cameraEntity.Get<CameraComponent>();
      cameraComponent.CameraFocus = body;
    }

  }
}

