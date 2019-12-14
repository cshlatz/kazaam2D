using Kazaam.Objects;

namespace Kazaam.Components{
  public class PlayerComponent {
    public IPlayer _player;

    public PlayerComponent(IPlayer player) {
      _player = player;
    }
  }
}
