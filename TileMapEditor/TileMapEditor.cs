using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using PeachFox.TileMapEditor;

namespace PeachFox
{
    public partial class TileMapEditorForm : Form
    {
        private ProjectSettings _projectSettings = new ProjectSettings();

        private Tilemap _tilemap;

        private LayerList _layerList;

        public TileMapEditorForm()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += KeyShortcuts;

            AddViewPort();

            AddMenuStrip();

            buttonNewTile.Click += (sender, e) => Program.NewTileSetSelectionForm(new List<string>(_projectSettings.TileSets.Keys), true, NewTileSelectCallback);

            buttonEditTile.Click += (sender, e) =>
            {
                int index = GetSelectedTileIndex();
                if (index == -1)
                {
                    _layoutTiles.Flash();
                    return;
                }
                Tile tile = _tilemap.Tiles[index];
                if (tile is ClassicTile classicTile)
                    Program.TileEditor.ShowTileEditor(_projectSettings.TileSets[classicTile.Image], false, classicTile, index);
                else //TODO
                { }
            };

            AddTileUi();

            _layerList = new LayerList(flowLayoutPanelLayers);

            buttonLayerNew.Click += (sender, e) =>
            {
                Program.NewLayerEditorForm(LayerCallback);
            };

            buttonLayerEdit.Click += (sender, e) =>
            {
                if (_layerList.SelectedItem != null)
                    Program.NewLayerEditorForm(LayerCallback, _layerList.SelectedItem.Layer);
            };

            AddTools();

            NewTilemap(16);
        }

        private void SaveTilemap(object sender, EventArgs e)
        {
            saveFileDialog.Filter = "(*.lua)|*.lua|All files (*.*)|*.*";
            DialogResult result = saveFileDialog.ShowDialog();
            if (result == DialogResult.OK || result == DialogResult.Yes)
            {
                System.IO.File.WriteAllText(saveFileDialog.FileName, Lua.LuaTilemap.ToLua(_tilemap));
            }
        }

        public void NewTilemap(int cellsize)
        {
            _tilemap = new Tilemap();
            SetCellSize(cellsize);
            ClearTiles();
            _layerList.Clear();
            _layerList.Tilemap = _tilemap;
            UpdateLayers();

            RedrawViewPort();
        }

        public void OpenTilemap(int cellsize, Tilemap tilemap)
        {
            _tilemap = tilemap;
            _layerList.Tilemap = _tilemap;
            SetCellSize(cellsize);
            ClearTiles();

            Dictionary<string, Image> images = new Dictionary<string, Image>();
            for (int i = 0; i < _tilemap.Tiles.Count; i++)
            {
                Tile tile = _tilemap.Tiles[i];
                if (tile is ClassicTile classicTile)
                {
                    List<int> quads = classicTile.Quads;
                    if (quads.Count < 4)
                        continue;
                    if (_projectSettings.TileSets.ContainsKey(classicTile.Image))
                    {
                        if (images.ContainsKey(_projectSettings.TileSets[classicTile.Image].Path) == false)
                            images[_projectSettings.TileSets[classicTile.Image].Path] = new Bitmap(_projectSettings.TileSets[classicTile.Image].Path);
                        _tileMapViewPort.Images[i] = ViewPort.CropImage(images[_projectSettings.TileSets[classicTile.Image].Path], quads[0], quads[1], quads[2], quads[3], quads[2], quads[3]);

                        AddNewTileButton(tile, ViewPort.CropImage(images[_projectSettings.TileSets[classicTile.Image].Path], quads[0], quads[1], quads[2], quads[3], 40, 40));
                    }
                    else
                    {
                        MessageBox.Show($"No tile set {classicTile.Image}, load your project settings or reimport TileSets!", "Missing textures");
                        NewTilemap(cellsize);
                        return;
                    }
                }
                else
                    AddNewTileButton(tile, null);
            }

            _layerList.Clear();

            for (int i = 0; i < _tilemap.Layers.Count; i++)
            {
                _layerList.Add(_tilemap.Layers[i], toolTip);
            }

            RedrawViewPort();
        }


        public void NewTileSet(TileSet.TileSetData tileSetData)
        {
            if (tileSetData != null)
            {
                if (tileSetData.PreviousExportString != null && tileSetData.PreviousExportString != tileSetData.ExportString)
                {
                    _projectSettings.TileSets.Remove(tileSetData.PreviousExportString);
                    if (_tilemap.Tiles != null)
                        foreach (Tile tile in _tilemap.Tiles)
                            if (tile is ClassicTile classicTile)
                                if (classicTile.Image == tileSetData.PreviousExportString)
                                    classicTile.Image = tileSetData.ExportString;
                }

                _projectSettings.TileSets[tileSetData.ExportString] = tileSetData;

                SetTileSelectionMenuItem();
            }
        }

        private void PaintTile()
        {
            Layer layer = _layerList.SelectedItem?.Layer;
            if (layer == null)
            {
                _layerList.Flash();
                return;
            }
            Button button = _tileButtons.SelectedButton;
            if (button == null || button.Tag == null)
            {
                _layoutTiles.Flash();
                return;
            }
            Tile tag = (Tile)button.Tag;
            int index = _tilemap.Tiles.FindIndex(tile => tile == tag);
            if (index == -1)
            {
                MessageBox.Show("Could not find selected Tile from selected Tile button");
                return;
            }

            int layertileindex = layer.Tiles.FindIndex(tile => tile.X == _tileMapViewPort.GetCell.X && tile.Y == _tileMapViewPort.GetCell.Y);
            if (layertileindex == -1)
            {
                LayerTile layerTile = new LayerTile
                {
                    Index = index,
                    X = _tileMapViewPort.GetCell.X,
                    Y = _tileMapViewPort.GetCell.Y,
                };
                layer.Tiles.Add(layerTile);
            }
            else
            {
                LayerTile layerTile = layer.Tiles[layertileindex];
                layerTile.Index = index;
            }
        }

        private void EraseTile()
        {
            Layer layer = _layerList.SelectedItem.Layer;
            if (layer == null)
            {
                _layerList.Flash();
                return;
            }
            if (layer.Tiles == null)
                return;
            int index = layer.Tiles.FindIndex(tile => tile.X == _tileMapViewPort.GetCell.X && tile.Y == _tileMapViewPort.GetCell.Y);
            if (index != -1)
                layer.Tiles.RemoveAt(index);
        }

        private void NewTileSelectCallback(string selectedName)
        {
            if (selectedName != null)
                Program.TileEditor.ShowTileEditor(_projectSettings.TileSets[selectedName], false);
        }

        private void NewBitmaskTileSelectCallback(string selectedName)
        {
            if (selectedName != null)
                Program.TileEditor.ShowTileEditor(_projectSettings.TileSets[selectedName], true);
        }

        private void SelectCallback(string selectedName)
        {
            if (selectedName != null)
                Program.NewTileSetNewForm(NewTileSetCallback, _projectSettings.TileSets[selectedName]);
        }

        private void NewTileSetCallback(TileSet.TileSetData tileSetData)
        {
            NewTileSet(tileSetData);
        }

        private void LayerCallback(Layer layer)
        {
            if (layer == null)
                return;

            if (_tilemap.Layers.Contains(layer) == false)
            {
                _tilemap.Layers.Add(layer);
                _layerList.Add(layer, toolTip);
            }
            else
                _layerList.SelectedItem?.UpdateName();
        }

        private void KeyShortcuts(object sender, KeyEventArgs e)
        {
            switch ((char)e.KeyValue)
            {
                case 'E':
                    _toolButtons.SetSelectedButton(buttonToolEraser);
                    e.Handled = true;
                    break;
                case 'P':
                case 'B':
                    _toolButtons.SetSelectedButton(buttonToolPaint);
                    e.Handled = true;
                    break;
                case 'M':
                    _toolButtons.SetSelectedButton(buttonToolMove);
                    e.Handled = true;
                    break;
                case 'S':
                    if (e.Control)
                    {
                        SaveTilemap(sender, e);
                        e.Handled = true;
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
