//-----------------------------------------------------------------------------
// Player.cs
//
// Kazaam Simple Game Engine
// Copyright (C) Connor Shlatz. All rights reserved.
//-----------------------------------------------------------------------------
using Kazaam.Input;

namespace Kazaam.Objects {
  public interface IPlayer {
    InputHandler InputHandler { get; set; }
    void HandleInput();
  }
}
