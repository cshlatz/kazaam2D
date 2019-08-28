using System.IO;

namespace Kazaam.Assets {

  /// <summary>
  /// A loader that can create specific Kazaam object types from a Stream.
  /// </summary>
  public interface ITypeLoader {
    object Load(Stream assetStream);
  }
}
