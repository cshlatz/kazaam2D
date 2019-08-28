using Kazaam.Enums;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Kazaam.Objects {

  /// <summary>
  /// A CreatureObject whose behavior is defined by user input.
  /// </summary>
  public abstract class PlayerObject: CreatureObject {
    protected PlayerObject(Texture2D texture, Vector2 position, float scale) : base (texture, position, scale) {
      // Empty constructor
    }

    private Vector2 MovementSpeed;

    public void Move(float speed) {
      SetVelocityX(speed);
    }

    public void Jump() {
      if (OnGround) {
        OnGround = false;
        SetVelocityY(-1000);
      }
    }
  }
}
