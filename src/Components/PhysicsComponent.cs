namespace Kazaam.Universe {
  public class PhysicsComponent {
    public float gravityAcceleration;
    public IPhysicsStrategy physicsStrategy;

    public PhysicsComponent(float grav) {
      gravityAcceleration = grav;
    }
  }
}
