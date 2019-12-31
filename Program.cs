using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

namespace PeachFox
{
    static class Program
    {
        private static TileEditorForm _tileEditorForm;
        private static TileMapEditorForm _tileMapEditorForm;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            _tileEditorForm = new TileEditorForm();
            _tileEditorForm.NewTilesetImage(new Bitmap("C:\\dev\\YogGJ\\Assets\\Logo.png"),
                new List<int>(){0,0,16,16, 16,16,16,16, 64,64,16,16});

            _tileMapEditorForm = new TileMapEditorForm();
            Application.Run(_tileMapEditorForm);
        }
    }
}
