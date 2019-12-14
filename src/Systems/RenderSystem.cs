using System;
using Kazaam.Components;
using Kazaam.Display;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using MonoGame.Extended.Entities;
using MonoGame.Extended.Entities.Systems;
using IDrawable = Kazaam.Objects.IDrawable;

namespace Kazaam.View {
    public class RenderSystem : EntityDrawSystem {
        private readonly XNAGame _game;

        private ComponentMapper<Background> _backgroundMapper;
        private ComponentMapper<RenderComponent> _renderMapper;
        private ComponentMapper<Body> _bodyMapper;
        private ComponentMapper<AnimationComponent> _animationMapper;

        public RenderSystem(XNAGame game) : base(Aspect.One(typeof(RenderComponent))) {
            _game = game;
        }

        public override void Initialize(IComponentMapperService mapperService) {
            _animationMapper = mapperService.GetMapper<AnimationComponent>();
            _backgroundMapper = mapperService.GetMapper<Background>();
            _bodyMapper = mapperService.GetMapper<Body>();
            _renderMapper = mapperService.GetMapper<RenderComponent>();
        }

        public override void Draw(GameTime gameTime) {
            var transformMatrix = _game.scene.CameraManager.View;
            _game.GameWindow.spriteBatch.Begin(transformMatrix : transformMatrix, samplerState: SamplerState.PointClamp, sortMode: SpriteSortMode.FrontToBack);

            foreach (var entity in ActiveEntities) {
                // Every renderable object has these
                var body = _bodyMapper.Get(entity);
                var renderComponent = _renderMapper.Get(entity);

                Rectangle sourceRectangle = new Rectangle();
                if (_animationMapper.Has(entity)) {
                    var animation = _animationMapper.Get(entity);
                    sourceRectangle = animation.CurrentAnimation.CurrentRectangle;
                    animation.CurrentAnimation.Update((float)gameTime.ElapsedGameTime.TotalMilliseconds);
                }

                // Draw background. If not a background, draw the object normally.
                if (_backgroundMapper.Has(entity)) {
                    var background = _backgroundMapper.Get(entity);
                    //_game.GameWindow.spriteBatch.Draw(background.Texture.Texture, new Vector2(_game.scene.CameraManager.Position.X - _game.scene.CameraManager.Viewport.Width / 2, _game.scene.CameraManager.Position.Y - _game.scene.CameraManager.Viewport.Height / 4), background.Rectangle(_game.scene.CameraManager.Viewport), Color.White, 0, Vector2.Zero, background.Zoom, SpriteEffects.None, background.LayerDepth);
                    //_game.GameWindow.spriteBatch.Draw(background.Texture.Texture, new Vector2(_game.scene.CameraManager.Position.X - _game.scene.CameraManager.Viewport.Width / 2, _game.scene.CameraManager.Position.Y - _game.scene.CameraManager.Viewport.Height / 2), background.Rectangle(_game.scene.CameraManager.Viewport), Color.White, 0, Vector2.Zero, background.Zoom, SpriteEffects.None, background.LayerDepth);
                } else {
                    DrawObject(body, sourceRectangle, renderComponent);
                }
            }

            // End the spritebatch.
            _game.GameWindow.spriteBatch.End();
        }

        public void DrawObject(Body body, Rectangle sourceRectangle, RenderComponent renderComp) {
          try {
            SpriteEffects effects = renderComp.Effects;
            Color tint = renderComp.DisplayTint;
            if (tint == null) tint = Color.White;
            // This is convoluted, but this allows the user to set a default direction that the texture faces
            // The render component assumes that the texture faces right (X axis increases left to right in the engine)
            // so operate under that assumption.

            _game.GameWindow.spriteBatch.Draw(
                 renderComp.Texture,
                 new Vector2(body.Position.X * renderComp.Scale, body.Position.Y * renderComp.Scale),
                 sourceRectangle,
                 tint,
                 0f,
                 Vector2.Zero,
                 renderComp.Scale,
                 effects,
                 renderComp.DisplayOrder
              );
          } catch (NullReferenceException e) {
          }
        }

    }
}
