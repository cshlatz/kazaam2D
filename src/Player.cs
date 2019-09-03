//-----------------------------------------------------------------------------
// Player.cs
//
// Kazaam Simple Game Engine
// Copyright (C) Connor Shlatz. All rights reserved.
//-----------------------------------------------------------------------------

using Kazaam.Input;
using Kazaam.Objects;
using Kazaam.Enums;

namespace Kazaam.Objects {

  /// <summary>
  /// This is the master player class that controls player input over a variety of screens
  /// including menus and gameplay
  /// </summary>
  public abstract class Player {
    public PlayerObject playerObject;
    public Scene activeScene;

    /// <summary>
    /// Called every frame to get updates on the master player object. Includes input and debugging
    /// </summary>
    public void Update(float delta) {
      if (playerObject.CurrentAnimation != null) {
        playerObject.CurrentAnimation.Update(delta);
      }
      HandleInput();
    }

    /// <summary>
    /// Handles all player input in the game. There can be multiple players, and therefore multiple inputs
    /// </summary>
    public virtual void HandleInput() {
      playerObject.state = playerObject.state.HandleInput(playerObject); 
    }

    /// <summary>
    /// Adds a PlayerObject that can be controlled via input through this class
    /// TODO: Add a collection of playerobjects for multiple local players.
    /// </summary>
    public void AddPlayerObject(PlayerObject player) {
      playerObject = player;
      playerObject.AddPhysicsBody(activeScene.world, 256, 256);
      activeScene._objects.Add(playerObject);
    }

    /// <summary>
    /// Sets the active scene for the player. This will change stuff like how
    /// input is handled, depending on the type of scene.
    /// </summary>
    public void SetActiveScene(Scene scene) {
      activeScene = scene;
    }

  }
}
