using HumperWorld = Humper.World;
using Kazaam.Camera;
using Kazaam.Loaders;
using Kazaam.Maps;
using Kazaam.Systems;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using MonoGame.Extended.Entities;
using SceneWorld = MonoGame.Extended.Entities.World;
using System.Collections.Generic;

namespace Kazaam {
    /// <summary>
    /// A collection of Kazaam.Universe objects that define a world in the engine.
    /// </summary>
    public class Scene {
        private readonly XNAGame Game;
        private Map _map;

        /// <summary>
        /// Returns the active GameWindow
        /// </summary>
        public XNAWindow XNAWindow {
            get {
                return Game.GameWindow;
            }
        }

        /// <summary>
        /// Returns the active GameWindow
        /// </summary>
        public GraphicsDevice Graphics {
            get {
                return Game.Graphics;
            }
        }

        /// <summary>
        /// A stack of GameStates. The top of the stack will update and drawa.
        /// </summary>
        public Stack<GameState> States { get; set; }

        /// <summary>
        /// Loads/builds assets from json files such as scenes and animations
        /// </summary>
        public ContentManager Content { get; set; }

        /// <summary>
        /// Loads/builds assets from json files such as scenes and animations
        /// </summary>
        public AssetLoader JsonLoader { get; set; }

        /// <summary>
        /// Loads content from files built with the pipeline tool
        /// </summary>
        public ContentLoader ContentLoader { get; set; }

        /// <summary>
        /// The scene's actively drawn and updated map
        /// </summary>
        public Map Map {
            get {
                return _map;
            }
            set {
                _map = value;
                _map.Scene = this;
                Maps.Add(_map); 
            }
        }

        /// <summary>
        /// The scene's currently loaded background track
        /// </summary>
        public Song Song { get; set; }

        /// <summary>
        /// The scene's currently loaded UI
        /// </summary>
        public Gui Gui { get; set; }

        /// <summary>
        /// The collection of entities, components and systems that exist in this scene
        /// </summary>
        public SceneWorld SceneWorld { get; set; }

        /// <summary>
        /// A manager that can interface with several different camera types
        /// </summary>
        public CameraManager CameraManager { get; set; }

        /// <summary>
        /// The collection of all collidable and moveable objects in the game world
        /// </summary>
        public GameWorld CollisionBodies { get; set; }

        /// <summary>
        /// If the scene contains multiple maps, a list to store them all
        /// </summary>
        public List<Map> Maps { get; set; }

        /// <summary>
        /// Returns the resolution scale of the game
        /// </summary>
        public Vector2 ResolutionScale {
            get {
                return Game.GameWindow.ResolutionScale;
            }
        }

        public Scene(XNAGame game) {
            this.Game = game;
            Content = game.Content;
            Initialize();
        }

        /// <summary>
        /// Initializes all scene variables that need to be initialized
        /// </summary>
        public virtual void Initialize() {
            //Initialize the ECS
            InitializeECS();

            // Initialize the Humper GameWorld
            CollisionBodies = new GameWorld(64000, 64000);

            // Initialize the loaders
            // Json Asset loader
            JsonLoader = new AssetLoader(new JsonFileStream());
            JsonLoader.RegisterType("animations", new AnimationLoader());
            JsonLoader.RegisterType("ui", new UILoader());

            // XNB Asset loader
            ContentLoader = new ContentLoader(Content);
            ContentLoader.RegisterType("maps", new MapLoader());
            ContentLoader.RegisterType("sounds", new SoundLoader());
            ContentLoader.RegisterType("songs", new SongLoader());
            ContentLoader.RegisterType("sprites", new SpriteLoader());

            // Initialize the camera
            CameraManager = new CameraManager();

            // Initialize any lists and stacks
            Maps = new List<Map>();
            States = new Stack<GameState>();
        }

        /// <summary>
        /// Initializes the ECS system. Users should override this method if custom systems are implemented.
        /// </summary>
        public virtual void InitializeECS() {
            SceneWorld = new WorldBuilder()
                .AddSystem(new PlayerSystem())
                .AddSystem(new PhysicsSystem())
                .AddSystem(new RenderSystem(this))
                .Build();
            SceneWorld.Initialize();
        }

        public Entity CreateEntity() {
            var entity = SceneWorld.CreateEntity();
            return entity;
        }

        /// <summary>
        /// Plays a background track, ending any currently active song
        /// </summary>
        public static void PlayBackgroundTrack(Song song) {
            MediaPlayer.Play(song);
        }

        /// <summary>
        /// Pauses the current background track, with progress saved
        /// </summary>
        public static void PauseBackgroundTrack() {
            MediaPlayer.Pause();
        }

    }
}

