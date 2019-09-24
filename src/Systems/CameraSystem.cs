using Kazaam.Objects;

using Microsoft.Xna.Framework;

using MonoGame.Extended.Entities;
using MonoGame.Extended.Entities.Systems;
using MonoGame.Extended.ViewportAdapters;

namespace Kazaam.View {
  public class CameraSystem : EntityProcessingSystem {
    private ComponentMapper<Body> _bodyMapper;
    private ComponentMapper<CameraComponent> _cameraMapper;
    private readonly XNAGame game;
    private int xres;
    private int yres;

    public CameraSystem(XNAGame game) : base(Aspect.All(typeof(CameraComponent), typeof(Body))) {
      this.game = game;
      xres = (int)game.Resolution.X;
      yres = (int)game.Resolution.Y;
    }

    public override void Initialize(IComponentMapperService mapperService) {
      _cameraMapper = mapperService.GetMapper<CameraComponent>();
      _bodyMapper = mapperService.GetMapper<Body>();
    }

    public override void Process(GameTime gameTime, int entityId) {
      var body = _bodyMapper.Get(entityId);
      var camera = _cameraMapper.Get(entityId);

      // Update the camera's position to the current focus
      var viewportAdapter = new BoxingViewportAdapter(game.Window, game.GraphicsDevice, xres, yres);
      var center = new Vector2(viewportAdapter.VirtualWidth/2f, viewportAdapter.VirtualHeight/2f);
      var centerOfObject = new Vector2(camera.CameraFocus.Position.X + (camera.CameraFocus.Bounds.Width / 2), camera.CameraFocus.Position.Y + (camera.CameraFocus.Bounds.Height / 2));
      body.Position = centerOfObject;
      camera.InternalCamera.Position = body.Position -= center;

      // Make any updates such as zoom to the matrix.
      Matrix cameraMatrix = camera.InternalCamera.GetViewMatrix();

      // Update the scene's current transform matrix
      game.scene.CameraMatrix = cameraMatrix;
    }
  }
}
