using Kazaam.Components;

namespace Kazaam.System{
    public interface IEntity {
        GameObject GameObject {get; set;}
        int Id { get; }
    }
}
