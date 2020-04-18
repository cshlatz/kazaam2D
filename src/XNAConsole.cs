using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

using System.Collections.Generic;

namespace Kazaam {
    public class XNAConsole {
        private XNAGame Game;
        public Scene Scene;
        private SpriteBatch spriteBatch;
        private Texture2D consoleWindow;
        private SpriteFont font;

        private bool blink;
        private int blinkTimer;

        private string InputKeyDisplay;
        private const string INPUT_KEY = "|";

        private Stack<string> buffer;

        public XNAConsole(XNAGame game) {
            Game = game;
            spriteBatch = new SpriteBatch(Game.Graphics);
            buffer = new Stack<string>();
            buffer.Push("");
            ToggleOn();
            blinkTimer = 50;
        }

        public void Display() {
            BlinkInputKey();
            spriteBatch.Begin();
            spriteBatch.Draw(consoleWindow, new Rectangle(0, 0, 1024, 768 / 2), Color.White);
            spriteBatch.DrawString(font, buffer.Peek() + InputKeyDisplay, new Vector2(10, (768 / 2) - 16), Color.White);
            spriteBatch.End();
        }

        public void ToggleOn() {
            // Load the rect that will be the console display window
            consoleWindow = new Texture2D(Game.Graphics, Game.GameWindow.XResolution, Game.GameWindow.YResolution / 2);
            Color[] data = new Color[Game.GameWindow.XResolution * (Game.GameWindow.YResolution / 2)];
            for (int i = 0; i < data.Length; i++) {
                data[i] = Color.Black;
            }
            consoleWindow.SetData(data);

            // Load the console's font
            font = Game.Content.Load<SpriteFont>("res/spritefont/console");
        }

        private void BlinkInputKey() {
            if (blinkTimer > 0) {
                blinkTimer--;
            }

            if (blinkTimer == 0) {
                blink = !blink;
                blinkTimer = 100;
            }

            if (blink) {
                InputKeyDisplay = " ";
            } else {
                InputKeyDisplay = INPUT_KEY;
            }
        }

        public void HandleKeyPress(Keys key) {
            switch (key) {
                case Keys.Back:
                    Delete();
                    break;
                default:
                    Insert(key.ToString());
                    break;
            }
        }

        public void Insert(string charValue) {
            string current = buffer.Pop();
            current = current + charValue;
            buffer.Push(current);
        }

        public void Delete() {
            string current = buffer.Pop();
            if (current.Length > 0) {
                current = current.Substring(0, current.Length - 1);
            }
            buffer.Push(current);
        }
    }
}
