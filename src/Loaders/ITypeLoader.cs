using System.IO;

namespace Kazaam.Loaders {
  /// <summary>
  /// A loader that can create specific Kazaam object types from a Stream.
  /// </summary>
  public interface ITypeLoader {
    object Load(Stream assetStream);
  }
}
