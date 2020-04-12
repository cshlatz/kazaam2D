using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Kazaam {
    public class XNAConsole {
        private XNAGame Game;
        public Scene Scene;
        private SpriteBatch spriteBatch;
        private Texture2D consoleWindow;

        public XNAConsole(XNAGame game) {
            Game = game;
            spriteBatch = new SpriteBatch(Game.Graphics);
            ToggleOn();
        }

        public void Display() {
            spriteBatch.Begin();
            spriteBatch.Draw(consoleWindow, new Rectangle(0, 0, 1024, 768 / 2), Color.White);
            spriteBatch.End();
        }

        public void ToggleOn() {
            consoleWindow = new Texture2D(Game.Graphics, Game.GameWindow.XResolution, Game.GameWindow.YResolution / 2);
            Color[] data = new Color[Game.GameWindow.XResolution * (Game.GameWindow.YResolution / 2)];
            for (int i = 0; i < data.Length; i++) {
                data[i] = Color.Black;
            }
            consoleWindow.SetData(data);
        }
    }
}
