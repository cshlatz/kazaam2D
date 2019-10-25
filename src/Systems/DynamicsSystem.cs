using Kazaam.Objects;
using Kazaam.Universe;
using Microsoft.Xna.Framework;
using MonoGame.Extended.Entities;
using MonoGame.Extended.Entities.Systems;

namespace Kazaam.Universe {
  public class DynamicsSystem : EntityProcessingSystem {
    private ComponentMapper<PhysicsComponent> _physicsMapper;  
    private ComponentMapper<Body> _bodyMapper;

    public DynamicsSystem() : base(Aspect.All(typeof(PhysicsComponent), typeof(Body))) {
    }

    public override void Initialize(IComponentMapperService mapperService) {
      _physicsMapper = mapperService.GetMapper<PhysicsComponent>();
      _bodyMapper = mapperService.GetMapper<Body>();
    }

    public override void Process(GameTime gameTime, int entityId) {
      var physics = _physicsMapper.Get(entityId);
      var body = _bodyMapper.Get(entityId);
      physics.physicsStrategy.PhysicsBody = body;
      physics.physicsStrategy.Update(gameTime);
    }
  }
}
