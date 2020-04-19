using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Kazaam {
    public class ConsoleState : GameState {
        private XNAConsole console;
        private XNAGame game;

        public ConsoleState(XNAGame game) {
            this.game = game;
            console = new XNAConsole(game);
        }

        public override void Update(GameTime gameTime) {
            KeyboardState kb = Keyboard.GetState();
            if (kb.IsKeyDown(Keys.OemTilde)) {
                game.Scene.States.Pop();
            }
        }

        public override void Draw(GameTime gameTime) {
            console.Render();
        }
    }
}
