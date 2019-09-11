using Kazaam.Assets;
using Microsoft.Xna.Framework.Graphics;

namespace Kazaam.Objects {
  public class RenderComponent {
    public Texture2D Texture {get; set;}  
    public SpriteEffects Effects {get; set;}
    public int Scale {get; set;}

    public RenderComponent(Sprite sprite, bool flip = false, int scale = 1) {
      Texture = sprite.Texture;
      Effects = flip ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
      Scale = scale;
    }
  }
}
