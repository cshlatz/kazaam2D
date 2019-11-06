using System;
using Kazaam.Components;
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

    public RenderSystem(XNAGame game) : base(Aspect.One(typeof(RenderComponent))) {
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
        Rectangle sourceRectangle = body.CurrentAnimation.CurrentRectangle;
        var transformMatrix = _game.scene.CameraManager.View;
        _game.GameWindow.spriteBatch.Begin(transformMatrix : transformMatrix, samplerState: SamplerState.PointClamp);
        _game.GameWindow.spriteBatch.Draw(
             renderComp.Texture,
             new Vector2(body.Position.X * renderComp.Scale, body.Position.Y * renderComp.Scale),
             sourceRectangle,
             Color.White,
             0f,
             Vector2.Zero,
             renderComp.Scale,
             effects,
             0f
          );
        _game.GameWindow.spriteBatch.End();
      } catch (NullReferenceException e) {
      }
    }

  }
}
