using System.IO;

namespace Kazaam.Assets {
  
  /// <summary>
  /// A stream for files in the JSON file format.
  /// </summary>
  public class JsonFileStream : IAssetStreamProvider {
    public Stream GetStream(string type, string name) {
      var file = new FileStream("res/" + type + "/" + name, FileMode.Open, FileAccess.Read);
      return file;
    }
  }
}
