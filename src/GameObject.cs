using Kazaam.Animate;

using Humper;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Kazaam.Objects {

  /// <summary>
  /// An object that can be represented on the screen.
  /// </summary>
	public class GameObject{
		public void Draw(SpriteBatch sb, Scene scene) {
      try {
        SpriteEffects se = SpriteEffects.None;
        if (body.effects.Equals(null)) {
          body.effects = se;
        }
        Rectangle sourceRectangle = body.CurrentAnimation.CurrentRectangle;
        var transformMatrix = scene.mainCamera.GetViewMatrix();
        sb.Begin(transformMatrix : transformMatrix, samplerState: SamplerState.PointClamp);
        foreach (Hitbox hb in body.hitboxes) {
          hb.Draw(sb, scene);
        }
			  sb.Draw(
             body.Texture,
             new Vector2(body.Bounds.X * body.Scale, body.Bounds.Y * body.Scale),
             sourceRectangle,
             Color.White,
             0f,
             Vector2.Zero,
             body.Scale,
             body.effects,
             0f
          );
			  sb.End();
      } catch (System.NullReferenceException e) {
      }
		}

		public virtual void Update(float delta) {
			return;
		}

    public void SetAnimation(Body body, Animation anim) {
      if (anim != null) {
        body.CurrentAnimation = anim;
      }
    }

	}
}
