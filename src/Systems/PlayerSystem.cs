using Kazaam.Components;
using Microsoft.Xna.Framework;
using MonoGame.Extended.Entities;
using MonoGame.Extended.Entities.Systems;

namespace Kazaam.Objects {
  public class PlayerSystem : EntityProcessingSystem {
    private ComponentMapper<Player> _playerMapper;
    private ComponentMapper<GameObject> _gameObjectMapper;

    public PlayerSystem() : base(Aspect.One(typeof(Player))) {
      
    }

    public override void Initialize(IComponentMapperService mapperService) {
      _gameObjectMapper = mapperService.GetMapper<GameObject>();
      _playerMapper = mapperService.GetMapper<Player>();
    }

    public override void Process(GameTime gameTime, int entityId) {
      var player = _playerMapper.Get(entityId)._player;
      var gameObject = _gameObjectMapper.Get(entityId);
      player.InputHandler.Update();
      player.HandleInput();
    }
  }
}
