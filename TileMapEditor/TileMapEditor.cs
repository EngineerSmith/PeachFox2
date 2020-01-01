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

            toolStripComboBox.SelectedIndexChanged += (sender, e) =>
            {
                if (toolStripComboBox.SelectedItem != null)
                    if (_tilesets.ContainsKey(toolStripComboBox.SelectedItem.ToString()))
                    {
                        Program.NewTileSetNewForm(NewTileSetCallback, _tilesets[toolStripComboBox.SelectedItem.ToString()]);
                        return;
                    }
                Program.NewTileSetSelectionForm(new List<string>(_tilesets.Keys), false, SelectCallback);
            };

            openFileDialog.Filter = "(*.tileset)|*.tileset|All files (*.*)|*.*";

            loadTileSetsToolStripMenuItem.Click += (sender, e) =>
            {
                DialogResult result = openFileDialog.ShowDialog();
                if (result == DialogResult.OK || result == DialogResult.Yes)
                {
                    TileSet.LuaTileSetLoad load = new TileSet.LuaTileSetLoad();
                    load.Open(System.IO.File.ReadAllText(openFileDialog.FileName));
                    _tilesets.Clear();
                    foreach (var set in load.TileSetData)
                        _tilesets[set.ExportString] = set;
                    SetTileSelectionMenuItem();
                }
            };

            saveFileDialog.Filter = openFileDialog.Filter;

            saveTileSetsToolStripMenuItem.Click += (sender, e) =>
            {
                DialogResult result = saveFileDialog.ShowDialog();
                if (result == DialogResult.OK || result == DialogResult.Yes)
                {
                    TileSet.LuaTileSetLoad save = new TileSet.LuaTileSetLoad();
                    save.TileSetData = new List<TileSet.TileSetData>(_tilesets.Values);
                    System.IO.File.WriteAllText(saveFileDialog.FileName, save.ToString());
                }
            };

            SetTileSelectionMenuItem();

            buttonNewTile.Click += (sender, e) =>
            {
                Program.NewTileSetSelectionForm(new List<string>(_tilesets.Keys), true, NewTileSelectCallback);
            };
        }

        public void NewTileSet(TileSet.TileSetData tileSetData)
        {
            if (tileSetData != null)
            {
                if (tileSetData.PreviousExportString != null && tileSetData.PreviousExportString != tileSetData.ExportString)
                {
                    _tilesets.Remove(tileSetData.PreviousExportString);
                    //TODO Update all tiles with new TileSet string
                }

                _tilesets[tileSetData.ExportString] = tileSetData;

                SetTileSelectionMenuItem();
            }
        }

        private void SetTileSelectionMenuItem()
        {
            toolStripComboBox.Items.Clear();
            toolStripComboBox.Items.AddRange(new List<string>(_tilesets.Keys).ToArray());
            editExistingTileSetToolStripMenuItem.Enabled = (toolStripComboBox.Items.Count != 0);
        }

        private void NewTileSelectCallback(string selectedName)
        {
            if (selectedName != null)
            {
                Bitmap image = new Bitmap(_tilesets[selectedName].Path);
                Program.TileEditor.NewTilesetImage(image);
            }
        }

        private void SelectCallback(string selectedName)
        {
            if (selectedName != null)
                Program.NewTileSetNewForm(NewTileSetCallback, _tilesets[selectedName]);
        }

        private void NewTileSetCallback(TileSet.TileSetData tileSetData)
        {
            NewTileSet(tileSetData);
        }
    }
}
