namespace Kazaam.System{
    public interface IEntity {
        int Id { get; }

        T GetComponent<T>();
    }
}
