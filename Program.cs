using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

namespace PeachFox
{
    static class Program
    {
        private static TileEditorForm _tileEditorForm;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            _tileEditorForm = new TileEditorForm();
            _tileEditorForm.NewTilesetImage(new Bitmap("C:\\dev\\YogGJ\\Assets\\Logo.png"),
                new List<int>(){ 0,0,16,16, 16,16,16,16, 64,64,16,16});
            Application.Run(_tileEditorForm);

        }
    }
}
