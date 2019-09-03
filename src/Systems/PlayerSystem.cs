using Microsoft.Xna.Framework;
using MonoGame.Extended.Entities;
using MonoGame.Extended.Entities.Systems;

namespace Kazaam.Objects {
  public class PlayerSystem : EntityProcessingSystem {
 // private ComponentMapper<Player> _playerMapper;
    private ComponentMapper<Body> _bodyMapper;

    public PlayerSystem() : base(Aspect.All(typeof(Body))) {
      
    }

    public override void Initialize(IComponentMapperService mapperService) {
      _bodyMapper = mapperService.GetMapper<Body>();
//    _playerMapper = mapperService.GetMapper<Player>();
    }

    public override void Process(GameTime gameTime, int entityId) {
      var body = _bodyMapper.Get(entityId);
      body.state.HandleInput(body);
    }
  }
}
