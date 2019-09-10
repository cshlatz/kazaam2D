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
        DrawObject(body, renderComponent.Texture, renderComponent.effects);
        if (body.CurrentAnimation != null) {
          body.CurrentAnimation.Update((float)gameTime.ElapsedGameTime.TotalMilliseconds);
        }
      }
    }

    public void DrawObject(Body body, Texture2D texture, SpriteEffects effects) {
      try {
        SpriteEffects se = SpriteEffects.None;
        if (effects.Equals(null)) {
          effects = se;
        }
        Rectangle sourceRectangle = body.CurrentAnimation.CurrentRectangle;
        var transformMatrix = _game.scene.mainCamera.GetViewMatrix();
        _game.GameWindow.spriteBatch.Begin(transformMatrix : transformMatrix, samplerState: SamplerState.PointClamp);
        foreach (Hitbox hb in body.hitboxes) {
          hb.Draw(_game.GameWindow.spriteBatch, _game.scene);
        }
			  _game.GameWindow.spriteBatch.Draw(
             texture,
             new Vector2(body.Bounds.X * body.Scale, body.Bounds.Y * body.Scale),
             sourceRectangle,
             Color.White,
             0f,
             Vector2.Zero,
             body.Scale,
             effects,
             0f
          );
			  _game.GameWindow.spriteBatch.End();
      } catch (System.NullReferenceException e) {
      }
    }

  }
}
