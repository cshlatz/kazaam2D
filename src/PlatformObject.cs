using Humper;

namespace Kazaam.Objects
{

  /// <summary>
  /// A GameObject that acts as a physical boundary for PhysicsObject bodies.
  /// </summary>
  public class PlatformObject  {
    public IBox Bounds;

		public PlatformObject(int width, int height, int x, int y, Scene scene) {
			Bounds = scene.world.Create(x, y, width, height);
      Bounds.AddTags(Enums.Tags.Platforms);
    }
  }
}
