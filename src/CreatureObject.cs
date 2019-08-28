using Kazaam.Enums;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

/// <summary>
/// Kazaam.Objects is a group of classes that represent objects that can be rendered to the screen.
/// \details If a class can be represented with a position on the screen or world, it is an Object of some sort, and should implement
/// the IDrawable interface. There are three distinct object types.<br><br>
/// <b>GameObjects</b><br>
/// These are objects that act as their own entity with positions on the screen or game world. This can represent platforms, obstacles, creatures, enemies, players and more.
/// GameObject entities also can contain various animations that change depending on their State.<br><br>
/// <b>Hitboxes</b><br>
/// A Hitbox is an abstract term for any sort of bound attached to a GameObject. These bounds can cause special behavior with the GameObject when colliding with another
/// Hitbox. For example, a CreatureObject that can throw a punch may have a "hurtbox" that can damage enemy CreatureObject entities when it collides with their Hitbox.<br><br>
/// <b>Drawables</b><br>
/// These don't represent a GameObject that can be interacted with, but rather things like the Background, Decorations and the UI.
/// </summary>
namespace Kazaam.Objects {

  /// <summary>
  /// An object with represents a living entity with predefined behavior.
  /// </summary>
  public class CreatureObject : PhysicsObject {
    public CreatureObject(Texture2D texture, Vector2 position, float scale) : base (texture, position, scale) {
    }
  }
}
