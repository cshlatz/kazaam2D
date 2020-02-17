using Kazaam.Components;

namespace Kazaam {

  /// <summary>
  /// A representation of the current state of an object, such as an idle object or a walking object.
  /// </summary>
  public abstract class ObjectState<T> where T : GameObject {
      public abstract ObjectState<T> HandleInput(T gameObject);
      public abstract void Enter(T gameObject);
      public abstract void Exit(T gameObject);
      public abstract void Update(T gameObject);
  }
}
