using System.IO;

namespace Kazaam.Assets {
  
  /// <summary>
  /// An implementation of IAssetStreamProvider for files built with the MonoGame Pipeline Tool.
  /// </summary>
  public class XNBFileStream : IAssetStreamProvider {
    public Stream GetStream(string type, string name) {
      var file = new FileStream(name, FileMode.Open, FileAccess.Read);
      return file;
    }
  }
}
