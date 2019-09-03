using Kazaam.Objects;
using Microsoft.Xna.Framework;
using MonoGame.Extended;
using MonoGame.Extended.Entities;
using MonoGame.Extended.Entities.Systems;
using World = Humper.World;

namespace Platformer.Systems
{
    public class WorldSystem : EntityProcessingSystem
    {
        private readonly World _world;
        private ComponentMapper<Transform2> _transformMapper;
        private ComponentMapper<Body> _bodyMapper;

        public WorldSystem()
            : base(Aspect.All(typeof(Body), typeof(Transform2)))
        {
            _world = new World(120 * 32, 120 * 32);
        }

        public override void Initialize(IComponentMapperService mapperService)
        {
            _bodyMapper = mapperService.GetMapper<Body>();
        }

        protected override void OnEntityAdded(int entityId)
        {
            var body = _bodyMapper.Get(entityId);
            _world.Create(body.Position.X, body.Position.Y, body.Dimensions.X, body.Dimensions.Y);
        }

        protected override void OnEntityRemoved(int entityId)
        {
            var body = _bodyMapper.Get(entityId);
            _world.Remove(body.Bounds);
        }

        public override void Process(GameTime gameTime, int entityId) {
          var body = _bodyMapper.Get(entityId);
        }
    }
}
