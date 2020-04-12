using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Kazaam {
    public class ConsoleState : GameState {
        private XNAConsole console;
        private XNAGame Game;

        public ConsoleState(XNAGame game) {
            Game = game;
            console = new XNAConsole(game);
        }

        public override void Update(GameTime gameTime) {
            KeyboardState kb = Keyboard.GetState();
            if (kb.IsKeyDown(Keys.OemTilde)) {
                Game.Scene.States.Pop();
            }
        }

        public override void Draw(GameTime gameTime) {
            console.Display();
        }
    }
}
