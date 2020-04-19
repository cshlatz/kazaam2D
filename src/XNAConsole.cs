using System;
using System.IO;
using System.Reflection;
using Myra;
using Myra.Graphics2D.UI;

namespace Kazaam {
    public class XNAConsole : Gui {

        private TextBox InputTextBox {
            get {
                return (TextBox)Project.Root.FindWidgetById("console-input");
            }
        }

        private TextBox HistoryTextBox {
            get {
                return (TextBox)Project.Root.FindWidgetById("console-history");
            }
        }

        public XNAConsole(XNAGame game) : base(game) {
            Assembly assembly = Assembly.GetExecutingAssembly();
            StreamReader reader = new StreamReader(assembly.GetManifestResourceStream("kazaam.res.gui.xnaconsole.xml"));
            string xmlgui = reader.ReadToEnd();
            LoadFromXML(xmlgui);
            Toggle();
        }

        public string ReturnConsoleCommand() {
            return InputTextBox.Text;
        }

        public void SetInputText(string input) {
            var inputBox = InputTextBox;
            inputBox.Text = input;
        }

        public void SetHistoryText(string text) {
            var historyBox = HistoryTextBox;
            historyBox.Text = historyBox.Text + text + Environment.NewLine;
        }
    }
}
