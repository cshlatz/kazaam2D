using Kazaam.Objects;
using Microsoft.Xna.Framework;
using MonoGame.Extended;
using MonoGame.Extended.Entities;
using MonoGame.Extended.Entities.Systems;
using World = Humper.World;

namespace Kazaam.Universe
{
    public class WorldSystem : EntityProcessingSystem, IDrawSystem {
        private readonly World _world;
        private ComponentMapper<Transform2> _transformMapper;
        private ComponentMapper<Body> _bodyMapper;
        private XNAGame _game;

        public WorldSystem(XNAGame game)
            : base(Aspect.All(typeof(Body)))
        {
            _world = new World(120 * 32, 120 * 32);
            _game = game;
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

        protected override void OnEntityChanged(int entityId)
        {
            base.OnEntityChanged(entityId);
        }

        public override void Process(GameTime gameTime, int entityId) {
          var body = _bodyMapper.Get(entityId);
        }

        public void Draw(GameTime gameTime)
        {
            _game.scene.Map.Draw(_game.GameWindow.spriteBatch, _game.scene);
        }
    }
}
