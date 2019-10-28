using Kazaam.Animate;
using Kazaam.Enums;

using Humper;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;

using System.Collections.Generic;

namespace Kazaam.Objects {
  public enum BodyType {
    Static, Dynamic
  }

  public class Body {
    // Static
    public IBox Bounds { get; set; }
    public Vector2 Position { get; set; }
    public Vector2 Dimensions { get; set; }
    public float Scale { get; set; }
    public Texture2D Texture { get; set; }
    public Animation CurrentAnimation { get; set; }
    public Dictionary<string, Animation>  animations;
    public Dictionary<string, SoundEffect> sounds;
    public ObjectState<IEntity> state;
    public bool facingRight;
    public List<Hitbox> hitboxes;

    // Dynamics
    public bool GravityEnabled { get; set; } // On by default
    public float GravityAcceleration { get; set; }
    public bool OnGround { get; set; }
    public Vector2 Velocity { get; set; }

    public Body() {
      animations = new Dictionary<string, Animation>();
      sounds = new Dictionary<string, SoundEffect>();
      hitboxes = new List<Hitbox>();
    }

    public void SetTexture(Texture2D tex) {
      Texture = tex;
    }

    public void SetAnimation(Animation anim) {
      if (anim != null) {
        CurrentAnimation = anim;
      }
    }
  }

}
