namespace Kazaam.Enums {
  using System;

  [Flags]
  public enum Tags {
    Creatures = 1 << 0,
    Platforms = 1 << 1,
    Enemies = 1 << 2
  }
}
