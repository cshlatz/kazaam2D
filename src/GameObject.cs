using Kazaam.Animate;
using Kazaam.Universe;

using Humper;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;

using System.Collections.Generic;

namespace Kazaam.Objects {

  /// <summary>
  /// An object that can be represented on the screen.
  /// </summary>
	public abstract class GameObject : IDrawable{
		public IBox Bounds { get; set; }
		public Vector2 Position { get; set; }
		public Vector2 Velocity { get; set; }
		public float Scale { get; set; }
		public Texture2D Texture { get; set; }
    public Animation CurrentAnimation { get; set; }
    public Dictionary<string, Animation>  animations;
    public Dictionary<string, SoundEffect> sounds;
    public SpriteEffects effects;

    public ObjectState state;
    public bool facingRight;

    public List<Hitbox> hitboxes;

		public GameObject(Texture2D texture, Vector2 position, float scale) {
			this.Texture = texture;
			this.Position = position;
			this.Scale = scale;
      animations = new Dictionary<string, Animation>();
      sounds  = new Dictionary<string, SoundEffect>();
      hitboxes = new List<Hitbox>();
		}

		public void Draw(SpriteBatch sb, Scene scene) {
      try {
        SpriteEffects se = SpriteEffects.None;
        if (effects.Equals(null)) {
          effects = se;
        }
        Rectangle sourceRectangle = CurrentAnimation.CurrentRectangle;
        var transformMatrix = scene.mainCamera.GetViewMatrix();
        sb.Begin(transformMatrix : transformMatrix, samplerState: SamplerState.PointClamp);
        foreach (Hitbox hb in hitboxes) {
          hb.Draw(sb, scene);
        }
			  sb.Draw(
             Texture,
             new Vector2(Bounds.X * Scale, Bounds.Y * Scale),
             sourceRectangle,
             Color.White,
             0f,
             Vector2.Zero,
             Scale,
             effects,
             0f
          );
			  sb.End();
      } catch (System.NullReferenceException e) {
      }
		}

		public virtual void Update(float delta) {
			return;
		}

    public void SetAnimation(Animation anim) {
      if (anim != null) {
        CurrentAnimation = anim;
      }
    }

    public abstract void AddPhysicsBody(World world, float width, float height);

	}
}
