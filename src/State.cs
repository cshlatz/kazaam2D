namespace Kazaam.Enums {
  using System;

  [Flags]
  public enum State {
    IDLE = 1 << 0,
    WALK = 1 << 1,
    JUMP = 1 << 2,
    HIT = 1 << 4
  }
}
