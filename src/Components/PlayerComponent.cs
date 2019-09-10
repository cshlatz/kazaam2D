using Kazaam.Objects;

namespace Kazaam.Player {
  public class PlayerComponent {
    public IPlayer _player;

    public PlayerComponent(IPlayer player) {
      _player = player;
    }
  }
}
