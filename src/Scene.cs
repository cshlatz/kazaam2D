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

    public Scene(XNAGame game) {
      this.Game = game;
      
      HumperWorld = new HumperWorld(120 * 32, 120 * 32);
    }

    /// <summary>
    /// The default implementation of an ECS world
    /// </summary>
    public void InitializeWorld() {
       SceneWorld = new WorldBuilder()
         .AddSystem(new WorldSystem(Game))
         .AddSystem(new PlayerSystem())
         .AddSystem(new RenderSystem(Game))
         .AddSystem(new DynamicsSystem())
         .AddSystem(new CameraSystem(Game))
         .AddSystem(new UISystem(Game))
         .Build();
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

  }
}

