using Kazaam.Enums;

using Humper;
using Humper.Responses;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using System;
using System.Linq;

namespace Kazaam.Objects {

  /// <summary>
  /// A GameObject that is affected by physics and collisions.
  /// </summary>
  public class PhysicsObject : GameObject {
    // Gravity Properties
    public bool GravityEnabled { get; set; } // On by default
    public float GravityAcceleration { get; set; }
    public bool OnGround { get; set; }

    public PhysicsObject(Texture2D texture, Vector2 position, float scale) : base (texture, position, scale) {
      // Gravity defaults. Can be changed on a per object basis.
      OnGround = false;
      GravityEnabled = true;
      GravityAcceleration = 10;
    }

    public override void AddPhysicsBody(World world, float width, float height) {
      Bounds = world.Create(Position.X, Position.Y, width, height);
    }

    public override void Update(float delta) {
      OnGround = false;
      Vector2 otherPosition;
      delta *= 0.001f;
      if (GravityEnabled) {
        SetVelocityY(Velocity.Y + GravityAcceleration);
      }
      Vector2 oldPosition = new Vector2(Bounds.X, Bounds.Y);
      var result = Bounds.Move(Bounds.X + (delta * Velocity.X), Bounds.Y + delta * Velocity.Y, (collision) => {
        // Check to see if there's a special collision response...
        return CheckCollisionResponse(collision);
      });

      // If you're not touching a platform, you're no longer on the ground!
      if (result.Hits.Any((c) => c.Box.HasTag(Enums.Tags.Platforms) && c.Normal.Y < 0/**/)) {
        if (result.Hits.Count() == 1) {
          SetVelocityY(0);
          OnGround = true;
        }
      }
      Position = new Vector2(Bounds.X, Bounds.Y);
      MoveHitboxes();
    }

    public void MoveHitboxes() {
      foreach (Hitbox hb in hitboxes) {
        hb.Bounds.Move(Position.X + hb.Position.X, Position.Y + hb.Position.Y, (c) => {
          return CollisionResponses.None;
        });
      }
    }

    public virtual CollisionResponses CheckCollisionResponse(ICollision collision) {
      if (collision.Other.HasTag(Enums.Tags.Platforms)) {
        return CollisionResponses.Slide;
      } else {
        return CollisionResponses.None;
      }
      return CollisionResponses.None;
    }

    public void SetVelocityX(float xVelocity) {
      Vector2 vel = Velocity;
      vel.X = xVelocity;
      Velocity = vel;
    }

    public void SetVelocityY(float yVelocity) {
      Vector2 vel = Velocity;
      vel.Y = yVelocity;
      Velocity = vel;
    }
  }
}
