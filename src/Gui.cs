using Myra;
using Myra.Graphics2D.UI;

namespace Kazaam.Display {
  public class Gui {
    private readonly Desktop desktop;
    private Project project;
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

    /// <summary>
    /// Get: returns the Myra project object
    /// Set: Sets the Myra project and the grid
    /// </summary>
    public Project Project {
      get {
        return project;
      }
      set {
        project = value;
        grid = (Grid)project.Root;
        Add(grid);
      }
    }

    public void Add(Widget item) {
      desktop.Widgets.Add(item);
    }

    public void Toggle() {
      Active = !Active;
    }

    public void DebugShowGridLines() {
      grid.ShowGridLines = !grid.ShowGridLines;
    }

    /// <summary>
    /// Returns a 2D UI Widget by ID. The object will need to be cast to the appropriate UI element.
    /// </summary>
    public Widget FindWidgetById(string id) {
      return project.Root.FindWidgetById(id);
    }
  }
}
