using Kazaam.Assets;
using Kazaam.Display;
using Kazaam.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections;
using System;

namespace Kazaam {
    /// <summary>
    /// The main game engine class that handles the game loop, physics updates and rendering.
    /// </summary>
    public class XNAGame : Game {
      public Stack states;
      public Vector2 Resolution;
      public Scene scene;
      public AssetLoader jsonLoader;
      public ContentLoader contentLoader;

      public XNAWindow GameWindow { get; set; }

      public GraphicsDevice Graphics { get {
        return GraphicsDevice;
      } }

      public XNAGame () {
        GameWindow = new XNAWindow(this);
        SetResolution(1280, 720);
      }

      protected override void Initialize() {
        base.Initialize();
        InitializeEngine();
        InitializeWorld();
        InitializeLoaders();
        InitializeInput();
      }

      public virtual void InitializeEngine() {
        IsFixedTimeStep = false;
        states = new Stack();
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

        // XNB Asset loader
        contentLoader = new ContentLoader(this);
        contentLoader.RegisterType("maps", new MapLoader());
        contentLoader.RegisterType("sounds", new SoundLoader());
        contentLoader.RegisterType("songs", new SongLoader());
        contentLoader.RegisterType("sprites", new SpriteLoader());
      }

      protected void SetResolution(int x, int y) {
        Resolution = new Vector2(x, y);
        GameWindow.Window().PreferredBackBufferWidth = (int)Resolution.X;
        GameWindow.Window().PreferredBackBufferHeight = (int)Resolution.Y;
        GameWindow.Window().ApplyChanges();
      }

      protected override void Draw(GameTime gameTime) {
        GraphicsDevice.Clear(Color.Black);
        scene.SceneWorld.Draw(gameTime);
        base.Draw(gameTime);
      }

      protected override void Update(GameTime gameTime) {
        scene.SceneWorld.Update(gameTime);
        InputManager.Update(); // Input manager is ALWAYS called
        base.Update(gameTime);
      }

      public static void Log(string message) {
        Console.WriteLine(message);
      }
    }

}
