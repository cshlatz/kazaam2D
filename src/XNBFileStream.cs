using System.IO;

namespace Kazaam.Assets {
  
  /// <summary>
  /// An implementation of IAssetStreamProvider for files built with the MonoGame Pipeline Tool.
  /// </summary>
  public class XNBFileStream : IAssetStreamProvider {
    public string path;

    public Stream GetStream(string type, string name) {
      #if (DEBUG)
        path = "../bin/Debug/" + type + "/" + name;
      #else
        path = "../bin/Release/" + type + "/" + name;
      #endif
      var file = new FileStream(path, FileMode.Open, FileAccess.Read); 
      return file;
    }
  }
}
