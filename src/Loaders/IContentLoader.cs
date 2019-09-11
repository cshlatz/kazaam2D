namespace Kazaam.Assets {
  public interface IContentLoader {
    object Load(XNAGame game, string contentPath);
  }
}
