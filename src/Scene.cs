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
    public Camera mainCamera;
    public GameObjectFactory factory; 
		public ArrayList _objects = new ArrayList();

		public float Gravity { get; }
    public Vector2 Vec { get; set; }


		public Scene(XNAGame game, SceneWorld world) {
			this.game = game;
      this.sworld = world;

      // Setup the gameobject factory
      factory = new GameObjectFactory(sworld, this.game.Content);

      // World physics
			Gravity = 9.8f;

      // Camera
      mainCamera = new Camera(game);
		}

    public void SetCameraFocus(Body focus) {
      mainCamera.CameraFocus = focus;
    }

    public void CreateObject(Body body) {
      factory.CreateGameObject(body);
    }

		public ArrayList SceneObjects() {
			return _objects;
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

  }


}

