using Kazaam.Assets;
using Kazaam.Display;
using Kazaam.Objects;
using Kazaam.Input;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections;

namespace Kazaam {
    /// <summary>
    /// The main game engine class that handles the game loop, physics updates and rendering.
    /// </summary>
    public class XNAGame : Game {
      public Stack states;
      public Vector2 Resolution;
      public Scene scene;
      public Player player;
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
            Console.WriteLine("bar");
        base.Initialize();
        states = new Stack();
        scene = new Scene(this);
				InputManager.Initialize();
        IsFixedTimeStep = false;

        // Json Asset loader
        jsonLoader = new AssetLoader(this, new JsonFileStream());
        jsonLoader.RegisterType("animations", new AnimationLoader());

        // XNB Asset loader
        contentLoader = new ContentLoader(this);
        contentLoader.RegisterType("maps", new MapLoader());
        contentLoader.RegisterType("sound", new SoundLoader());
        contentLoader.RegisterType("song", new SongLoader());
      }

      protected void SetResolution(int x, int y) {
        Resolution = new Vector2(x, y);
        GameWindow.Window().PreferredBackBufferWidth = (int)Resolution.X;
        GameWindow.Window().PreferredBackBufferHeight = (int)Resolution.Y;
        GameWindow.Window().ApplyChanges();
      }

      protected override void Draw(GameTime gameTime) {
        var state = (IGameState)states.Peek();
        state.Draw(gameTime);
        base.Draw(gameTime);
      }

      protected override void Update(GameTime gameTime) {
			  InputManager.Update(); // Input manager is ALWAYS called
        var state = (IGameState)states.Peek();
        state.Update(gameTime);
        base.Update(gameTime);
      }

      public void SetPlayer(Player player) {
        this.player = player;
      }

    }

}
