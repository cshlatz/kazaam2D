using System;
using Kazaam.Objects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using MonoGame.Extended.Entities;
using MonoGame.Extended.Entities.Systems;
using IDrawable = Kazaam.Objects.IDrawable;

namespace Kazaam.View {
  public class RenderSystem : EntityDrawSystem {
    private readonly XNAGame _game;

    private ComponentMapper<RenderComponent> _renderMapper;
    private ComponentMapper<Body> _bodyMapper;

    public RenderSystem(XNAGame game) : base(Aspect.All(typeof(RenderComponent))) {
      _game = game;
    }
    
    public override void Initialize(IComponentMapperService mapperService) {
      _renderMapper = mapperService.GetMapper<RenderComponent>();
      _bodyMapper = mapperService.GetMapper<Body>();
    }

    public override void Draw(GameTime gameTime) {
      foreach (var entity in ActiveEntities) {
        var body = _bodyMapper.Get(entity);
        var renderComponent = _renderMapper.Get(entity);
        DrawObject(body, renderComponent);
        if (body.CurrentAnimation != null) {
          body.CurrentAnimation.Update((float)gameTime.ElapsedGameTime.TotalMilliseconds);
        }
      }
    }

    public void DrawObject(Body body, RenderComponent renderComp) {
      try {
        SpriteEffects effects = renderComp.Effects;

        // This is convoluted, but this allows the user to set a default direction that the texture faces
        // The render component assumes that the texture faces right (X axis increases left to right in the engine)
        // so operate under that assumption.
        if (body.facingRight) {
          effects = effects.HasFlag(SpriteEffects.FlipHorizontally) ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
        } else {
          effects = effects.HasFlag(SpriteEffects.FlipHorizontally) ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
        }

        Rectangle sourceRectangle = body.CurrentAnimation.CurrentRectangle;
        var transformMatrix = _game.scene.CameraManager.View;
        _game.GameWindow.spriteBatch.Begin(transformMatrix : transformMatrix, samplerState: SamplerState.PointClamp);

        foreach (Hitbox hb in body.hitboxes) {
          hb.Draw(_game.GameWindow.spriteBatch, _game.scene);
        }

        _game.GameWindow.spriteBatch.Draw(
             renderComp.Texture,
             new Vector2(body.Bounds.X * body.Scale, body.Bounds.Y * body.Scale),
             sourceRectangle,
             Color.White,
             0f,
             Vector2.Zero,
             renderComp.Scale,
             effects,
             0f
          );
        _game.GameWindow.spriteBatch.End();
      } catch (System.NullReferenceException e) {
      }
    }

  }
}
