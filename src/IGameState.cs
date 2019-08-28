using Microsoft.Xna.Framework;

namespace Kazaam {

  /// <summary>
  /// A representation of the current state of the game, such as active gameplay or paused gameplay.
  /// </summary>
  public interface IGameState {
    void Init(XNAGame game);
    void Cleanup();
  
    void Pause();
    void Resume();
  
    void Update(GameTime gameTime);
    void Draw(GameTime gameTime);
  }
}
