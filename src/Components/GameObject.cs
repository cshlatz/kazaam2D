using Kazaam.Objects;

namespace Kazaam.Components {
    public class GameObject {
        public IGameObject _gameObject;
        public GameObject(IGameObject gameObject) {
            _gameObject = gameObject;
        }
    }
}
