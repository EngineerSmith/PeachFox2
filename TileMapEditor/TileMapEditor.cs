using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using PeachFox.TileMapEditor;

namespace PeachFox
{
    public partial class TileMapEditorForm : Form
    {
        private TileMapViewPort _tileMapViewPort;
        private Dictionary<string, TileSet.TileSetData> _tilesets = new Dictionary<string, TileSet.TileSetData>();

        public TileMapEditorForm()
        {
            InitializeComponent();

            _tileMapViewPort = new TileMapViewPort(viewPort);

            addNewTileSetToolStripMenuItem.Click += (sender, e) =>
            {
                Program.NewTileSetNewForm(NewTileSetCallback);
            };

            editExistingTileSetToolStripMenuItem.Click += (sender, e) =>
            {
                Program.NewTileSetSelectionForm(new List<string>(_tilesets.Keys), false, SelectCallback);
            };
        }

        private void SelectCallback(string selectedName)
        {
            if (selectedName != null)
                Program.NewTileSetNewForm(NewTileSetCallback, _tilesets[selectedName]);
        }

        private void NewTileSetCallback(TileSet.TileSetData tileSetData)
        {
            if (tileSetData != null)
            {
                if (tileSetData.PreviousExportString != null && tileSetData.PreviousExportString != tileSetData.ExportString)
                {
                    _tilesets.Remove(tileSetData.PreviousExportString);
                    //TODO Update all tiles with new TileSet string
                }

                _tilesets[tileSetData.ExportString] = tileSetData;
            }
        }
    }
}
