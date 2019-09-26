using Kazaam.Objects;
using Kazaam.Universe;

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

        public int XResolution {get; private set;}
        public int YResolution {get; private set;}

        public XNAWindow(Game game) {
          this.game = game;

          graphics = new GraphicsDeviceManager(this.game);
          graphics.PreferMultiSampling = false;
          graphics.SynchronizeWithVerticalRetrace = false;
          graphics.ApplyChanges();

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
    }
}
