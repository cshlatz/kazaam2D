using Myra;
using Myra.Graphics2D.UI;
using System.IO;

namespace Kazaam.Display {
  public class Gui {
    private readonly Desktop desktop;
    private Grid grid;
    private bool Active;

    public Gui(XNAGame game) {
      desktop = new Desktop();
      MyraEnvironment.Game = game;
    }

    public void Render() {
      if (Active) {
        desktop.Render();
      }
    }

    public void LoadGui(string path) {
      string data = File.ReadAllText(path);
      Project project = Project.LoadFromXml(data);
      var projectgrid = (Grid)project.Root;
      grid = projectgrid;
      desktop.Widgets.Add(grid);
    }

    public void Toggle() {
      Active = !Active;
    }

    public void DebugShowGridLines() {
      grid.ShowGridLines = !grid.ShowGridLines;
    }

  }
}
