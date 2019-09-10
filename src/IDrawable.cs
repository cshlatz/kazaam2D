using Microsoft.Xna.Framework.Graphics;

namespace Kazaam.Objects {

  /// <summary>
  /// An object or texture that is drawable to the Window.
  /// </summary>
	public interface IDrawable {
		void Draw(SpriteBatch sb, Scene scene);
	}
}
