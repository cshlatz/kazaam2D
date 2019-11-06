using Kazaam.Components;
using Kazaam.Player;
using Microsoft.Xna.Framework;
using MonoGame.Extended.Entities;
using MonoGame.Extended.Entities.Systems;

namespace Kazaam.Objects {
  public class PlayerSystem : EntityProcessingSystem {
    private ComponentMapper<PlayerComponent> _playerMapper;
    private ComponentMapper<Body> _bodyMapper;

    public PlayerSystem() : base(Aspect.One(typeof(PlayerComponent))) {
      
    }

    public override void Initialize(IComponentMapperService mapperService) {
      _bodyMapper = mapperService.GetMapper<Body>();
      _playerMapper = mapperService.GetMapper<PlayerComponent>();
    }

    public override void Process(GameTime gameTime, int entityId) {
      var player = _playerMapper.Get(entityId)._player;
      var body = _bodyMapper.Get(entityId);
      player.HandleInput();
    }
  }
}
