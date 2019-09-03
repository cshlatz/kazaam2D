using Microsoft.Xna.Framework.Content;
using MonoGame.Extended.Entities;

namespace Kazaam.Objects {
  public class GameObjectFactory {
    private readonly World _world;
    private readonly ContentManager _contentManager;

    public GameObjectFactory(World world, ContentManager contentManager) {
      _world = world;
      _contentManager = contentManager;
    }

    public Entity CreateGameObject(Body body) {
      var entity = _world.CreateEntity();
      entity.Attach(body);
      entity.Attach(new Body());
      return entity;
    }
  }
}
