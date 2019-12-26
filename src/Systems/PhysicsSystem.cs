using Kazaam.Components;
using Microsoft.Xna.Framework;
using MonoGame.Extended.Entities;
using MonoGame.Extended.Entities.Systems;

namespace Kazaam.Systems {
    public class PhysicsSystem : EntityProcessingSystem {
        private ComponentMapper<PhysicsBody> _physicsMapper;  
        private ComponentMapper<GameObject> _bodyMapper;
  
        public PhysicsSystem() : base(Aspect.All(typeof(PhysicsBody))) {
        }
  
        public override void Initialize(IComponentMapperService mapperService) {
            _physicsMapper = mapperService.GetMapper<PhysicsBody>();
            _bodyMapper = mapperService.GetMapper<GameObject>();
        }
  
        public override void Process(GameTime gameTime, int entityId) {
            var physics = _physicsMapper.Get(entityId);
            var body = _bodyMapper.Get(entityId);
            physics.PhysicsStrategy.GameObject = body;
            physics.PhysicsStrategy.PhysicsBody = physics;
            physics.PhysicsStrategy.Update(gameTime);
        }
    }
}
