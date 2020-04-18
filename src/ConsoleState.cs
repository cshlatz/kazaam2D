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
            var kb = Keyboard.GetState();
            var keys = kb.GetPressedKeys();
            if (kb.IsKeyDown(Keys.OemTilde)) {
                Game.Scene.States.Pop();
            }
            if (keys.Length > 0) {
                console.HandleKeyPress(keys[0]);
            }
        }

        public override void Draw(GameTime gameTime) {
            console.Display();
        }
    }
}
