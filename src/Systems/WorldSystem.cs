using Kazaam.Components;
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
        private ComponentMapper<GameObject> _gameObjectMapper;
        private XNAGame _game;

        public WorldSystem(XNAGame game)
            : base(Aspect.All(typeof(GameObject)))
        {
            _world = new World(120 * 32, 120 * 32);
            _game = game;
        }

        public override void Initialize(IComponentMapperService mapperService)
        {
            _gameObjectMapper = mapperService.GetMapper<GameObject>();
        }

        protected override void OnEntityAdded(int entityId)
        {
            // TODO: This needs a more permanent solution.
            try {
            /*
              var body = _bodyMapper.Get(entityId);
              _world.Create(body.Position.X, body.Position.Y, body.Dimensions.X, body.Dimensions.Y);
            */
            } catch {

            }

        }

        public override void Process(GameTime gameTime, int entityId) {
            var gameObject = _gameObjectMapper.Get(entityId);
        }

        public void Draw(GameTime gameTime) {
            foreach (Map map in _game.scene.SceneMaps) {
              map.Draw(_game.GameWindow.spriteBatch, _game.scene);
            }
        }
    }
}
