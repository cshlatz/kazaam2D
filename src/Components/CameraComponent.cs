using Kazaam.Objects;
using Microsoft.Xna.Framework;
using MonoGame.Extended;

namespace Kazaam.View {
  public class CameraComponent {
    public Body CameraFocus {get; set;}
    public float Zoom {get; set;}
    public OrthographicCamera InternalCamera {get; set;} 
    public Matrix Matrix {get; set;}
  }
}
