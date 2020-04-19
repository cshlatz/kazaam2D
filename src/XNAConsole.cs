using System;
using System.IO;
using System.Reflection;
using Myra;
using Myra.Graphics2D.UI;

namespace Kazaam {
    public class XNAConsole : Gui {
        public XNAConsole(XNAGame game) : base(game) {
            Assembly assembly = Assembly.GetExecutingAssembly();
            StreamReader reader = new StreamReader(assembly.GetManifestResourceStream("kazaam.res.gui.xnaconsole.xml"));
            string xmlgui = reader.ReadToEnd();
            LoadFromXML(xmlgui);
            Toggle();
        }
    }
}
