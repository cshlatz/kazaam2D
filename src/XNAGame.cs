using Kazaam.Display;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;

namespace Kazaam {
    /// <summary>
    /// The main game engine class that handles the game loop, physics updates and rendering.
    /// </summary>
    public class XNAGame : Game {
        public Scene Scene { get; set; }
        public XNAWindow GameWindow { get; set; }

        public GraphicsDevice Graphics {
            get {
                return GraphicsDevice;
            }
        }

        public XNAGame () {
            GameWindow = new XNAWindow(this);
        }

        protected override void Initialize() {
            base.Initialize();
            IsFixedTimeStep = true; // Caps the engine at 60 FPS.
        }

        protected override void Draw(GameTime gameTime) {
            base.Draw(gameTime);
            GraphicsDevice.Clear(Color.White);
            try {
                if (Scene.States.Count > 0) {
                    Scene.States.Peek().Draw(gameTime);
                } else {
                    Log("Game State stack is empty in Draw");
                }
            } catch (NullReferenceException e) {
                Log("No Scene loaded");
                throw new NullReferenceException(e.ToString());
            }
        }

        protected override void Update(GameTime gameTime) {
            base.Update(gameTime);
            try {
                if (Scene.States.Count > 0) {
                    Scene.States.Peek().Update(gameTime);
                } else {
                    Log("Game State stack is empty in Update");
                }
            } catch (NullReferenceException e) {
                Log("No Scene loaded");
                throw new NullReferenceException(e.ToString());
            }
        }

        public static void Log(string message) {
            #if DEBUG
            Console.WriteLine(DateTime.Now + ": "  + message);
            #endif
        }
    }
}
