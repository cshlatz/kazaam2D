using Humper;
using Humper.Responses;
using Kazaam.Enums;
using Kazaam.Objects;
using Kazaam.Universe;
using Microsoft.Xna.Framework;
using MonoGame.Extended.Entities;
using MonoGame.Extended.Entities.Systems;
using System;
using System.Linq;

namespace Kazaam.Universe {
  public class DynamicsSystem : EntityProcessingSystem {

    private ComponentMapper<Body> _bodyMapper;  
    private ComponentMapper<PhysicsComponent> _physicsMapper;  

    public DynamicsSystem() : base(Aspect.One(typeof(PhysicsComponent))) {
    }

    public override void Initialize(IComponentMapperService mapperService) {
      _bodyMapper = mapperService.GetMapper<Body>();
      _physicsMapper = mapperService.GetMapper<PhysicsComponent>();
    }

    public override void Process(GameTime gameTime, int entityId) {
      float delta = (float)gameTime.ElapsedGameTime.TotalMilliseconds;
      var body = _bodyMapper.Get(entityId);
      var physics = _physicsMapper.Get(entityId);
      body.OnGround = false;
      Vector2 otherPosition;
      delta *= 0.001f;
      if (body.GravityEnabled) {
        SetVelocityY(body, body.Velocity.Y + physics.gravityAcceleration);
      }
      Vector2 oldPosition = new Vector2(body.Bounds.X, body.Bounds.Y);
      var result = body.Bounds.Move(body.Bounds.X + (delta * body.Velocity.X), body.Bounds.Y + delta * body.Velocity.Y, (collision) => {
        // Check to see if there's a special collision response...
        return CheckCollisionResponse(collision);
      });

      // If you're not touching a platform, you're no longer on the ground!
      if (result.Hits.Any((c) => c.Box.HasTag(Enums.Tags.Platforms) && c.Normal.Y < 0/**/)) {
        if (result.Hits.Count() == 1) {
          SetVelocityY(body, 0);
          body.OnGround = true;
        }
      }
      body.Position = new Vector2(body.Bounds.X, body.Bounds.Y);
      MoveHitboxes(body);
    }

    public void SetVelocityX(Body body, float xVelocity) {
      Vector2 vel = body.Velocity;
      vel.X = xVelocity;
      body.Velocity = vel;
    }

    public void SetVelocityY(Body body, float yVelocity) {
      Vector2 vel = body.Velocity;
      vel.Y = yVelocity;
      body.Velocity = vel;
    }

    public virtual CollisionResponses CheckCollisionResponse(ICollision collision) {
      if (collision.Other.HasTag(Enums.Tags.Platforms)) {
        return CollisionResponses.Slide;
      } else {
        return CollisionResponses.None;
      }
      return CollisionResponses.None;
    }

    public void MoveHitboxes(Body body) {
      foreach (Hitbox hb in body.hitboxes) {
        hb.Bounds.Move(body.Position.X + hb.Position.X, body.Position.Y + hb.Position.Y, (c) => {
          return CollisionResponses.None;
        });
      }
    }
  }
}
