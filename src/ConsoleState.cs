using Microsoft.Xna.Framework;

namespace Kazaam {
    public class ConsoleState : GameState {
        private XNAConsole console;
        private XNAGame game;

        public ConsoleState(XNAGame game) {
            this.game = game;
            console = new XNAConsole(game);
        }

        public override void Update(GameTime gameTime) {

        }

        public override void Draw(GameTime gameTime) {
            console.Render();
        }
    }
}
