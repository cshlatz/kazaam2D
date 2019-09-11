using Kazaam.Assets;
using Kazaam.Display;
using Kazaam.Objects;
using Kazaam.Input;
using Kazaam.Universe;
using Kazaam.View;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

using MonoGame.Extended.Entities;

using System;
using System.Collections;

namespace Kazaam {
    /// <summary>
    /// The main game engine class that handles the game loop, physics updates and rendering.
    /// </summary>
    public class XNAGame : Game {
      protected World _world;
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
        _world = new WorldBuilder()
          .AddSystem(new WorldSystem(this))
          .AddSystem(new PlayerSystem())
          .AddSystem(new RenderSystem(this))
          .AddSystem(new DynamicsSystem())
          .AddSystem(new CameraSystem(this))
          .Build();

        Components.Add(_world);
        states = new Stack();
        scene = new Scene(this, _world);
        InputManager.Initialize();
        IsFixedTimeStep = false;

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
        GraphicsDevice.Clear(Color.BlanchedAlmond);
        _world.Draw(gameTime);
        base.Draw(gameTime);
      }

      protected override void Update(GameTime gameTime) {
        _world.Update(gameTime);
        InputManager.Update(); // Input manager is ALWAYS called
        base.Update(gameTime);
      }
    }

}
