namespace Kazaam.Objects {

  /// <summary>
  /// A representation of the current state of an object, such as an idle object or a walking object.
  /// </summary>
  public abstract class ObjectState<T> where T : IEntity {
    public abstract ObjectState<T> HandleInput(T entity);
    public abstract void Enter(T entity);
    public abstract void Exit(T entity);
    public abstract void Update(T entity);
  }
}
