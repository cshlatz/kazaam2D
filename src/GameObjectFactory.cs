using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using MonoGame.Extended.Entities;

namespace Kazaam.Objects {
  public class GameObjectFactory {
    protected readonly ContentManager _contentManager;
        private XNAGame game;

    public GameObjectFactory(XNAGame game) {;
      this.game = game;
      _contentManager = game.Content;
    }

    public int CreateEntity(List<object> list) {
      var entity = game.scene.sworld.CreateEntity();
            entity.Attach<Body>(new Body());
            foreach (var component in list)
            {
                entity.Attach(component);
            }
      return entity.Id;
    }

    public void Attach(int entityId, object obj) {
      var entity = game.scene.sworld.GetEntity(entityId);
      entity.Attach<object>(obj);
            return;
    }
  }
}
