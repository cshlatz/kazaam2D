using Myra.Graphics2D.UI;
using System.IO;

namespace Kazaam.Assets {
  public class UILoader : ITypeLoader {
    /// <summary>
    /// Returns a Myra Project from a provided XML file
    /// </summary>
    public object Load(Stream assetStream) {
      string xml;
      using (var sr = new StreamReader(assetStream)) {
        xml = sr.ReadToEnd();
      }

      var project = Project.LoadFromXml(xml);
      return project;
    }
  }
}
