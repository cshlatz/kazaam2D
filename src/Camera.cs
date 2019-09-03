using Kazaam.Objects;

using Microsoft.Xna.Framework;

using MonoGame.Extended;
using MonoGame.Extended.Graphics;
using MonoGame.Extended.ViewportAdapters;


/// <summary>
/// Kazaam.View is a group of classes that provide camera and viewport support for the engine.
/// </summary>
namespace Kazaam.View
{
  
  /// <summary>
  /// A camera that defines the region shown on the window.
  /// </summary>
  public class Camera {
    public PhysicsObject CameraFocus;
		protected Vector2 Position;
    protected float Zoom;
    protected XNAGame game;
    protected OrthographicCamera InternalCamera;

    // Platformer Camera limits
    protected float HorizontalFocusLimit;
    protected float VerticalFocusLimit;

    public Camera(XNAGame game) {
      this.game = game;
      var viewportAdapter = new BoxingViewportAdapter(game.Window, game.GraphicsDevice, (int)game.Resolution.X, (int)game.Resolution.Y);
      InternalCamera = new OrthographicCamera(viewportAdapter);
    }

    public void Update(GameTime gameTime) {
      SetPosition(CameraFocus.Position);
    }

    /// <summary>
    /// Centers the camera on a given position
    /// </summary>
    public void SetPosition(Vector2 position) {
      var viewportAdapter = new BoxingViewportAdapter(game.Window, game.GraphicsDevice, (int)game.Resolution.X, (int)game.Resolution.Y);
      var center = new Vector2(viewportAdapter.VirtualWidth/2f, viewportAdapter.VirtualHeight/2f);
      InternalCamera.Position = position -= center;
    }

    public Matrix GetViewMatrix() {
      return InternalCamera.GetViewMatrix();
    }

  }
}
