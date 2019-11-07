using Kazaam.Animate;
using Kazaam.Objects;
using Kazaam.System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;

using System.Collections.Generic;

namespace Kazaam.Components {
  public enum BodyType {
    Static, Dynamic
  }

  public class Body {
    public Vector2 Position { get; set; }
    public Vector2 Rotation { get; set; }
    public float Scale { get; set; }
    public Texture2D Texture { get; set; }
    public Animation CurrentAnimation { get; set; }
    public Dictionary<string, Animation>  animations;
    public Dictionary<string, SoundEffect> sounds;
    public ObjectState<IEntity> state;
    public List<Hitbox> Hitboxes { get; set; }

    public bool DebugDrawHitboxes { get; set; }

    public Body() {
      animations = new Dictionary<string, Animation>();
      sounds = new Dictionary<string, SoundEffect>();
      Hitboxes = new List<Hitbox>();
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
