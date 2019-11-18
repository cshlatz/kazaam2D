using Kazaam.Assets;
using Microsoft.Xna.Framework.Graphics;

namespace Kazaam.Components {
    public class RenderComponent {
        public Texture2D Texture {get; set;}
        public SpriteEffects Effects {get; set;}
        public float Scale {get; set;}
        public float DisplayOrder { get; set; }

        public RenderComponent(Sprite sprite, bool flip = false, float scale = 1.0f, float displayOrder = 0.0f) {
            Texture = sprite.Texture;
            Effects = flip ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
            Scale = scale;
            DisplayOrder = displayOrder;
        }
    }
}
