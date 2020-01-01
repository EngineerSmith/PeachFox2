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
        private static TileSetNewForm _tileSetNewForm;
        private static TileSetSelectionForm _tileSetSelectionForm;

        public static TileEditorForm TileEditor { get => _tileEditorForm; }
        public static TileMapEditorForm TileMapEditor { get => _tileMapEditorForm; }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            _tileEditorForm = new TileEditorForm();
            //_tileEditorForm.NewTilesetImage(new Bitmap("C:\\dev\\YogGJ\\Assets\\Logo.png"),
            //    new List<int>(){0,0,16,16, 16,16,16,16, 64,64,16,16});
            
            _tileMapEditorForm = new TileMapEditorForm();
            _tileMapEditorForm.Activated += (sender, e) =>
            {
                if (_tileSetSelectionForm != null)
                    _tileSetSelectionForm.Activate();
                if (_tileSetNewForm != null)
                    _tileSetNewForm.Activate();
            };
            Application.Run(_tileMapEditorForm);
        }

        public static void NewTileSetNewForm(NewTileSetCallback callback, TileSet.TileSetData data = null)
        {
            if (_tileSetNewForm != null)
                _tileSetNewForm.Close();
            _tileSetNewForm = new TileSetNewForm(callback, data);
            _tileSetNewForm.FormClosed += (sender, e) => { _tileSetNewForm = null; };
            _tileSetNewForm.Show();
            _tileSetNewForm.Activate();
        }
        public static void NewTileSetSelectionForm(List<string> tileSetNames, bool showNewTileSet, SelectFormCallback callback)
        {
            if (_tileSetSelectionForm != null)
                _tileSetSelectionForm.Close();
            _tileSetSelectionForm = new TileSetSelectionForm(tileSetNames, showNewTileSet, callback);
            _tileSetSelectionForm.FormClosed += (sender, e) => { _tileSetSelectionForm = null; };
            _tileSetSelectionForm.Show();
            _tileSetSelectionForm.Activate();
        }
    }
}
