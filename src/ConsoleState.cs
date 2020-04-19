using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

using Myra;

using System;
using System.Collections.Generic;

namespace Kazaam {
    public class ConsoleState : GameState {
        private XNAConsole console;
        private XNAGame game;
        private Stack<string> history;

        public ConsoleState(XNAGame game) {
            this.game = game;
            console = new XNAConsole(game);
            history = new Stack<string>();
        }

        public override void Update(GameTime gameTime) {
            KeyboardState kb = Keyboard.GetState();

            // Close the console
            if (kb.IsKeyDown(Keys.OemTilde)) {
                game.Scene.States.Pop();
            }

            // Take input from console input box. Push it to history stack. Clear console input.
            if (kb.IsKeyDown(Keys.Enter)) {
                // Verify input exists since IsKeyDown polls every frame. Then process the command.
                if (!String.IsNullOrEmpty(console.ReturnConsoleCommand())) {
                    string command = console.ReturnConsoleCommand();
                    history.Push(command);
                    console.SetHistoryText(history.Peek());
                    console.SetInputText("");
                    ProcessCommand(command);
                }
            }
        }

        public override void Draw(GameTime gameTime) {
            console.Render();
        }

        public void ProcessCommand(string command) {
            switch (command) {
                case "quit":
                    Environment.Exit(0);
                    break;
            }
        }
    }
}
