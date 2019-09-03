namespace Kazaam.Objects {
  /// <summary>
  /// An object that is effected by physical forces.
  /// </summary>
  interface IDynamic {
    void Update(float delta);
  }
}
