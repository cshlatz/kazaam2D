//-----------------------------------------------------------------------------
// Player.cs
//
// Kazaam Simple Game Engine
// Copyright (C) Connor Shlatz. All rights reserved.
//-----------------------------------------------------------------------------

namespace Kazaam.Objects {
  public interface IPlayer {
    void HandleInput();
    Body GetBody();
  }
}
