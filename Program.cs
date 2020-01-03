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
        private static LayerEditorForm _layerEditorForm;

        public static TileEditorForm TileEditor { get => _tileEditorForm; }
        public static TileMapEditorForm TileMapEditor { get => _tileMapEditorForm; }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            _tileEditorForm = new TileEditorForm();
            
            _tileMapEditorForm = new TileMapEditorForm();
            _tileMapEditorForm.Activated += (sender, e) =>
            {
                if (_tileSetSelectionForm != null)
                    _tileSetSelectionForm.Activate();
                if (_tileSetNewForm != null)
                    _tileSetNewForm.Activate();
                if (_layerEditorForm != null)
                    _layerEditorForm.Activate();
            };
            Application.Run(_tileMapEditorForm);
        }

        public static void NewTileSetNewForm(NewTileSetCallback callback, TileSet.TileSetData data = null)
        {
            _tileSetNewForm?.Close();
            _tileSetNewForm = new TileSetNewForm(callback, data);
            _tileSetNewForm.FormClosed += (sender, e) => { _tileSetNewForm = null; };
            _tileSetNewForm.Show();
            _tileSetNewForm.Activate();
        }
        public static void NewTileSetSelectionForm(List<string> tileSetNames, bool showNewTileSet, SelectFormCallback callback)
        {
            _tileSetSelectionForm?.Close();
            _tileSetSelectionForm = new TileSetSelectionForm(tileSetNames, showNewTileSet, callback);
            _tileSetSelectionForm.FormClosed += (sender, e) => { _tileSetSelectionForm = null; };
            _tileSetSelectionForm.Show();
            _tileSetSelectionForm.Activate();
        }

        public static void NewLayerEditorForm(LayerEditorCallback callback, Layer layer = null)
        {
            _layerEditorForm?.Close();
            _layerEditorForm = new LayerEditorForm(callback, layer);
            _layerEditorForm.FormClosed += (sender, e) => { _layerEditorForm = null; };
            _layerEditorForm.Show();
            _layerEditorForm.Activate();
        }
    }
}
