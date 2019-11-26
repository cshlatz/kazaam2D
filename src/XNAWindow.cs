using MonoGame.Extended.ViewportAdapters;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using System.Collections;


/// <summary>
/// Kazaam.Display is a group of classes that provide access to graphical displays and windows.
/// </summary>
namespace Kazaam.Display
{

    /// <summary>
    /// A window that displays graphics to the user.
    /// </summary>
    public class XNAWindow {
        private GraphicsDeviceManager graphics;
        private Game game;
        public SpriteBatch spriteBatch;
        private ArrayList sprites;
        public BoxingViewportAdapter ViewportAdapter {get; private set;}

        public int XResolution {get; private set;}
        public int YResolution {get; private set;}

        public int VirtualWidth {get; private set;}
        public int VirtualHeight {get; private set;}

        public Vector2 ResolutionScale {
            get {
                return new Vector2((float)graphics.GraphicsDevice.Viewport.Width / (float)VirtualWidth, (float)graphics.GraphicsDevice.Viewport.Width / (float)VirtualWidth);
            }
        }

        public XNAWindow(Game game) {
          this.game = game;
          createGraphics(false);
          sprites = new ArrayList();
          spriteBatch = new SpriteBatch(graphics.GraphicsDevice);
        }

        public GraphicsDeviceManager Window() {
          return graphics;
        }

        /// <summary>
        /// Changes the resolution of the game window.
        /// </summary>
        public void Resolution(int x, int y) {
          XResolution = x;
          YResolution = y;
          Window().PreferredBackBufferWidth = XResolution;
          Window().PreferredBackBufferHeight = YResolution;
          Window().ApplyChanges();
        }

        /// <summary>
        /// Changes the virtual resolution of the game window.
        /// </summary>
        public void VirtualResolution(int x, int y) {
          VirtualWidth = x;
          VirtualHeight = y;
        }

        /// <summary>
        /// Toggles fullscreen on and off.
        /// </summary>
        public void ToggleFullscreen() {
          graphics.IsFullScreen = !graphics.IsFullScreen;
          graphics.ApplyChanges();
        }

        /// <summary>
        /// Internal method to create the graphics device.
        /// </summary>
        private void createGraphics(bool fullscreen) {
          graphics = new GraphicsDeviceManager(game);
          graphics.PreferMultiSampling = false;
          graphics.SynchronizeWithVerticalRetrace = true;
          graphics.IsFullScreen = fullscreen;
          graphics.ApplyChanges();
        }
    }
}
