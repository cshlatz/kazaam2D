using HumperWorld = Humper.World;
using Kazaam.Display;
using Kazaam.Objects;
using Kazaam.Universe;
using Kazaam.Systems;
using Kazaam.View;
using Microsoft.Xna.Framework.Media;
using MonoGame.Extended.Entities;
using SceneWorld = MonoGame.Extended.Entities.World;
using System.Collections.Generic;
using Kazaam.System;

namespace Kazaam {
  
  /// <summary>
  /// A collection of Kazaam.Universe objects that define a world in the engine.
  /// </summary>
  public class Scene { 
    public Map Map {get; set;}
    public readonly XNAGame Game;
    public Song song;

    public Gui Gui {get; set;}

    public SceneWorld SceneWorld {get; set;}

    // Camera
    public CameraManager CameraManager {get; set;}

    public Scene(XNAGame game) {
      this.Game = game;
      CameraManager = new CameraManager();
    }

    public GameWorld CollisionBodies;
    public List<Map> SceneMaps {get; set;}

    /// <summary>
    /// The default implementation of an ECS world
    /// </summary>
    public void Initialize() {
      //Initialize the ECS
      SceneWorld = new WorldBuilder()
        .AddSystem(new WorldSystem(Game))
        .AddSystem(new PlayerSystem())
        .AddSystem(new PhysicsSystem())
        .AddSystem(new RenderSystem(Game))
        .Build();
      SceneWorld.Initialize();

      // Initialize the Humper GameWorld
      CollisionBodies = new GameWorld(64000, 64000);
    }

    public Entity CreateEntity() {
        var entity = SceneWorld.CreateEntity();
        return entity;
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

