using System;
using System.Windows.Forms;
using System.Drawing;

namespace PeachFox
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new TileEditorForm(new Bitmap("C:\\dev\\YogGJ\\Assets\\Logo.png")));
        }
    }
}
