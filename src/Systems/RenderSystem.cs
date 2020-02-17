using System;
using Kazaam.Components;
using Kazaam.Display;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using MonoGame.Extended.Entities;
using MonoGame.Extended.Entities.Systems;

namespace Kazaam.View {
    public class RenderSystem : EntityDrawSystem {
        private readonly Scene _scene;

        private ComponentMapper<Background> _backgroundMapper;
        private ComponentMapper<Renderer> _renderMapper;
        private ComponentMapper<GameObject> _gameObjectMapper;
        private ComponentMapper<Animator> _animationMapper;

        public RenderSystem(Scene scene) : base(Aspect.One(typeof(Renderer))) {
            _scene = scene;
        }

        public override void Initialize(IComponentMapperService mapperService) {
            _animationMapper = mapperService.GetMapper<Animator>();
            _backgroundMapper = mapperService.GetMapper<Background>();
            _gameObjectMapper = mapperService.GetMapper<GameObject>();
            _renderMapper = mapperService.GetMapper<Renderer>();
        }

        public override void Draw(GameTime gameTime) {
            if (_scene.CameraManager.View == null) {
                Kazaam.XNAGame.Log("Scene camera is not set, cannot render scene");
                return;
            }
            var transformMatrix = _scene.CameraManager.View;
            _scene.XNAWindow.spriteBatch.Begin(transformMatrix : transformMatrix, samplerState: SamplerState.PointClamp, sortMode: SpriteSortMode.FrontToBack);

            foreach (var entity in ActiveEntities) {
                // Every renderable object has these
                var gameObject = _gameObjectMapper.Get(entity);
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
                    //_game.XNAWindow.spriteBatch.Draw(background.Texture.Texture, new Vector2(_game.scene.CameraManager.Position.X - _game.scene.CameraManager.Viewport.Width / 2, _game.scene.CameraManager.Position.Y - _game.scene.CameraManager.Viewport.Height / 4), background.Rectangle(_game.scene.CameraManager.Viewport), Color.White, 0, Vector2.Zero, background.Zoom, SpriteEffects.None, background.LayerDepth);
                    //_game.XNAWindow.spriteBatch.Draw(background.Texture.Texture, new Vector2(_game.scene.CameraManager.Position.X - _game.scene.CameraManager.Viewport.Width / 2, _game.scene.CameraManager.Position.Y - _game.scene.CameraManager.Viewport.Height / 2), background.Rectangle(_game.scene.CameraManager.Viewport), Color.White, 0, Vector2.Zero, background.Zoom, SpriteEffects.None, background.LayerDepth);
                } else {
                    DrawObject(gameObject, sourceRectangle, renderComponent);
                }
            }

            // End the spritebatch.
            _scene.XNAWindow.spriteBatch.End();
        }

        public void DrawObject(GameObject gameObject, Rectangle sourceRectangle, Renderer renderComp) {
          try {
            SpriteEffects effects = renderComp.Effects;
            Color tint = renderComp.DisplayTint;
            if (tint == null) tint = Color.White;
            // This is convoluted, but this allows the user to set a default direction that the texture faces
            // The render component assumes that the texture faces right (X axis increases left to right in the engine)
            // so operate under that assumption.

            _scene.XNAWindow.spriteBatch.Draw(
                 renderComp.Texture,
                 new Vector2(gameObject.Position.X * renderComp.Scale, gameObject.Position.Y * renderComp.Scale),
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

        /*
        public void DrawMap(Map map) {
            var newMatrix = scene.CameraManager.View * Matrix.CreateTranslation((offsetX * scene.CameraManager.Zoom), (offsetY * scene.CameraManager.Zoom), 0);
            sb.Begin(samplerState: SamplerState.LinearWrap); // Draw the map
            foreach (Background bg in Backgrounds) {
                sb.Draw(bg.Texture.Texture, new Rectangle(0, 0, scene.CameraManager.Viewport.Width, scene.CameraManager.Viewport.Height), bg.Rectangle(scene.CameraManager.Viewport), Color.White);
            }
            sb.End();
            sb.Begin(transformMatrix: newMatrix, samplerState: SamplerState.PointClamp); // Draw the map
            _mapRenderer.Draw(newMatrix);
            sb.End();
        }
        */
    }
}
