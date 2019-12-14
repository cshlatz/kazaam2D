using Kazaam.Animate;
using System.Collections.Generic;
namespace Kazaam.Components {
    public class Animator {

        private Animation _currentAnimation;

        /// <summary>
        /// A dictionary of animations where the key is the animation name and the value is the set of animation frames
        /// </summary>
        public Dictionary<string, Animation>  Animations { get; set; }

        /// <summary>
        /// Gets and sets the current active frame in the animation
        /// </summary>
        public Animation CurrentAnimation { get {
            return _currentAnimation;
        }
        set {
            if (value != null) {
                _currentAnimation = value;
            }
        }}

        public Animator() {
            Animations = new Dictionary<string, Animation>();
        }
    }
}
