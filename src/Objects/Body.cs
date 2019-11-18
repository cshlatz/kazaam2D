using Kazaam.System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;

using System.Collections.Generic;

namespace Kazaam.Components {
  public enum BodyType {
    Static, Dynamic
  }

  public class Body {
    public Vector2 Position { get; set; }
    public Vector2 Rotation { get; set; }
    public float Scale { get; set; }
    public Dictionary<string, SoundEffect> sounds;
    public ObjectState<IEntity> state;
    public List<Hitbox> Hitboxes { get; set; }

    public bool DebugDrawHitboxes { get; set; }

    public Body() {
      sounds = new Dictionary<string, SoundEffect>();
      Hitboxes = new List<Hitbox>();
    }
  }

}
