using Kazaam.Input;

namespace Kazaam.Objects {

  /// <summary>
  /// A representation of the current state of an object, such as an idle object or a walking object.
  /// </summary>
  public abstract class ObjectState {
    public abstract ObjectState HandleInput(IPlayer player);
    public abstract void Enter(Body obj);
    public abstract void Exit(Body obj);
    public abstract void Update(Body obj);
  }
}
