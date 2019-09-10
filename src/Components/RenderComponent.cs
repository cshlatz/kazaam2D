using Microsoft.Xna.Framework.Graphics;

namespace Kazaam.Objects {
  public class RenderComponent {
    public Texture2D Texture {get; set;}  
    public SpriteEffects Effects {get; set;}
    public int Scale {get; set;}

    public RenderComponent(Texture2D texture, SpriteEffects effects = SpriteEffects.None, int scale = 1) {
      Texture = texture;
      Effects = effects;
      Scale = scale;
    }
  }
}
