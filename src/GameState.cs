using Microsoft.Xna.Framework;

namespace Kazaam {

    /// <summary>
    /// A representation of the current state of the game, such as active gameplay or paused gameplay.
    /// </summary>
    public abstract class GameState {
        public virtual void Cleanup() {

        }
      
        public virtual void Pause() {

        }

        public virtual void Resume() {

        }
      
        public abstract void Update(GameTime gameTime);
        public abstract void Draw(GameTime gameTime);
    }
}
