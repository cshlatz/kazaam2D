using Kazaam.Assets;
using Kazaam.Display;
using Kazaam.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System;

namespace Kazaam {
    /// <summary>
    /// The main game engine class that handles the game loop, physics updates and rendering.
    /// </summary>
    public class XNAGame : Game {
      private Stack<IGameState> _states;

      public Stack<IGameState> States {
        get {
            return _states;
        }
      }

      public Scene scene;
      public AssetLoader jsonLoader;
      public ContentLoader contentLoader;

      public XNAWindow GameWindow { get; set; }

      public GraphicsDevice Graphics { get {
        return GraphicsDevice;
      } }

      public XNAGame () {
        GameWindow = new XNAWindow(this);
      }

      protected override void Initialize() {
        base.Initialize();
        InitializeEngine();
        InitializeWorld();
        InitializeLoaders();
        InitializeInput();
      }

      public virtual void InitializeEngine() {
        IsFixedTimeStep = true; // Caps the engine at 60 FPS.
        _states = new Stack<IGameState>();
        scene = new Scene(this);
      }

      public virtual void InitializeWorld() {
        scene.InitializeWorld();
      }

      public virtual void InitializeInput() {
        InputManager.Initialize();
      }

      public virtual void InitializeLoaders() {
        // Json Asset loader
        jsonLoader = new AssetLoader(this, new JsonFileStream());
        jsonLoader.RegisterType("animations", new AnimationLoader());
        jsonLoader.RegisterType("ui", new UILoader());

        // XNB Asset loader
        contentLoader = new ContentLoader(this);
        contentLoader.RegisterType("maps", new MapLoader());
        contentLoader.RegisterType("sounds", new SoundLoader());
        contentLoader.RegisterType("songs", new SongLoader());
        contentLoader.RegisterType("sprites", new SpriteLoader());
      }

      protected override void Draw(GameTime gameTime) {
        base.Draw(gameTime);
        GraphicsDevice.Clear(Color.Black);
        States.Peek().Draw(gameTime);
      }

      protected override void Update(GameTime gameTime) {
        base.Update(gameTime);
        States.Peek().Update(gameTime);
      }

      public static void Log(string message) {
        Console.WriteLine(message);
      }
    }

}
