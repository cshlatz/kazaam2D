using Myra;
using Myra.Graphics2D.UI;
using System.IO;

namespace Kazaam.Display {
  public class Gui {
    private Desktop desktop;
    private Grid grid;
    public Gui(XNAGame game) {
      desktop = new Desktop();
      MyraEnvironment.Game = game;
    }

    public void Render() {
      desktop.Render();
    }

    public void LoadGui(string path) {
      string data = File.ReadAllText(path);
      Project project = Project.LoadFromXml(data);
      var projectgrid = (Grid)project.Root;
      grid = projectgrid;
      desktop.Widgets.Add(grid);
    }
  }
}
