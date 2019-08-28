using Kazaam.Input;

namespace Kazaam.Objects {

  /// <summary>
  /// A representation of the current state of an object, such as an idle object or a walking object.
  /// </summary>
  public abstract class ObjectState {
    public abstract ObjectState HandleInput(GameObject obj);
    public abstract void Enter(GameObject obj);
    public abstract void Exit(GameObject obj);
    public abstract void Update(GameObject obj);
  }
}
