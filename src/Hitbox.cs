// Copyright Connor R. Shlatz 2019
// Hitbox.cs

using Kazaam.Enums;
using Humper;
using Humper.Responses;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Kazaam.Components {
    public enum HitboxType {
        Hitbox,
        Hurtbox,
        BoundingBox
    }

    /// <summary>
    /// Represents the bounds of an object that interacts with other objects in the game world.
    /// </summary>
    public class Hitbox {
        private Vector2 _position;
        private Vector2 _offset;
        private Body _parent;

        /// <summary>
        /// The parent body of this hitbox. The position of the hitbox will be relative to the parent
        /// </summary>
        public Body Parent { get {
            return _parent; 
        } set {
            _parent = value;
            _offset = _position - _parent.Position;
        }}

        /// <summary>
        /// The position of the hitbox in the game world.
        /// </summary>
        public Vector2 Position {
            get {
                return _position;
            } private set {
                _position = value;
            }
        }

        /// <summary>
        /// The position of the hitbox relative to its parent.
        /// </summary>
        public Vector2 Offset {
            get {
                return _offset;
            }
        }

        /// <summary>
        /// The width of the hitbox.
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// The height of the hitbox.
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// An Axis Aligned Bounding Box that represents this object in the humper world.
        /// </summary>
        public IBox Bounds { get; set; }

        /// <summary>
        /// An Axis Aligned Bounding Box that represents this object in the humper world.
        /// </summary>
        public Hitbox(int x, int y, int width, int height) {
            this.Position = new Vector2(x, y);
            this.Width = width;
            this.Height = height;
        }

        /// <summary>
        /// Move the hitbox AABB to the specified coordinates with no concern of a collision response.
        /// </summary>
        public void Move(int x, int y) {
            Bounds.Move(x, y, (collision) => { return null;});
        }

        /// <summary>
        /// Adds a humper tag for collision response
        /// </summary>
        public void AddTag(Kazaam.Enums.Tags tag) {
            Bounds.AddTags(tag);
        }
    }
}
