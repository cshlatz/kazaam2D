using Kazaam.Objects;
using Drawable = Kazaam.Objects.IDrawable;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using MonoGame.Extended.Entities;
using MonoGame.Extended.Entities.Systems;

namespace Kazaam.View {
  public class RenderSystem : EntityDrawSystem {
    private readonly Scene _scene;
    private readonly GraphicsDevice graphicsDevice;
    private readonly SpriteBatch _spriteBatch;

    private ComponentMapper<Drawable> _drawableMapper;

    public RenderSystem(GraphicsDevice gd) : base(Aspect.All(typeof(Drawable))) {
      graphicsDevice = gd;
    }
    
    public override void Initialize(IComponentMapperService mapperService) {
      _drawableMapper = mapperService.GetMapper<Drawable>();
    }

    public override void Draw(GameTime gameTime) {
      foreach (var entity in ActiveEntities) {
        var drawable = _drawableMapper.Get(entity);
      }
    }

  }
}
