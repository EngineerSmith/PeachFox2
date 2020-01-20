﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using PeachFox.TileMapEditor;
using System.Linq;

namespace PeachFox
{
    public partial class TileMapEditorForm : Form
    {
        private TileMapViewPort _tileMapViewPort;
        public int CellSize { get => _tileMapViewPort.CellSize; }

        private Dictionary<string, TileSet.TileSetData> _tilesets = new Dictionary<string, TileSet.TileSetData>();

        private Tilemap _tilemap;

        private LayerList _layerList;

        private FlashableLayout _layoutTiles;

        private SelectableButtons _tileButtons = new SelectableButtons();
        private SelectableButtons _toolButtons = new SelectableButtons();

        public TileMapEditorForm()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += KeyShortcuts;

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

            SetTileSelectionMenuItem();

            loadTileSetsToolStripMenuItem.Click += (sender, e) =>
            {
                openFileDialog.Filter = "(*.tileset)|*.tileset|All files (*.*)|*.*";
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

            saveTileSetsToolStripMenuItem.Click += (sender, e) =>
            {
                saveFileDialog.Filter = "(*.tileset)|*.tileset|All files (*.*)|*.*";
                DialogResult result = saveFileDialog.ShowDialog();
                if (result == DialogResult.OK || result == DialogResult.Yes)
                {
                    TileSet.LuaTileSetLoad save = new TileSet.LuaTileSetLoad
                    {
                        TileSetData = new List<TileSet.TileSetData>(_tilesets.Values)
                    };
                    System.IO.File.WriteAllText(saveFileDialog.FileName, save.ToString());
                }
            };

            saveTilemapToolStripMenuItem.Click += SaveTilemap;

            newTilemapToolStripMenuItem.Click += (sender, e) =>
            {
                NewTilemap(16); //TODO add form prompt
            };

            helpToolStripMenuItem.Click += (sender, e) => System.Diagnostics.Process.Start("https://github.com/EngineerSmith/PeachFox2/wiki");

            openTilemapToolStripMenuItem.Click += (sender, e) =>
            {
                openFileDialog.Filter = "(*.lua)|*.lua|All files (*.*)|*.*";
                DialogResult result = openFileDialog.ShowDialog();
                if (result == DialogResult.OK || result == DialogResult.Yes)
                {
                    OpenTilemap(16, openFileDialog.FileName); //TODO add form prompt
                }
            };

            createTileToolStripMenuItem.Click += (sender, e) => Program.NewTileSetSelectionForm(new List<string>(_tilesets.Keys), true, NewTileSelectCallback);
            createBitmaskTileToolStripMenuItem.Click += (sender, e) => Program.NewTileSetSelectionForm(new List<string>(_tilesets.Keys), true, NewBitmaskTileSelectCallback);

            buttonNewTile.Click += (sender, e) => Program.NewTileSetSelectionForm(new List<string>(_tilesets.Keys), true, NewTileSelectCallback);

            buttonEditTile.Click += (sender, e) =>
            {
                int index = GetSelectedTileIndex();
                if (index == -1)
                {
                    _layoutTiles.Flash();
                    return;
                }

                Program.TileEditor.NewTilesetImage(_tilesets[_tilemap.Tiles[index].Image], false, GetSelectedTileButtonObject(), index);
            };

            flowLayoutPanelTiles.Click += (sender, e) => { _tileButtons.SetSelectedButton(null); };

            _layoutTiles = new FlashableLayout(flowLayoutPanelTiles);

            _layerList = new LayerList(flowLayoutPanelLayers);

            buttonLayerNew.Click += (sender, e) =>
            {
                Program.NewLayerEditorForm(LayerCallback);
            };

            buttonLayerEdit.Click += (sender, e) =>
            {
                if (_layerList.SelectedItem != null)
                    Program.NewLayerEditorForm(LayerCallback, _layerList.SelectedItem.Attributes.layer);
            };

            _toolButtons.Add(buttonToolMove);
            _toolButtons.Add(buttonToolPaint);
            _toolButtons.Add(buttonToolEraser);
            _toolButtons.Add(buttonToolTag);
            _toolButtons.SetSelectedButton(buttonToolMove);

            _toolButtons.Callback = () =>
            {
                _tileMapViewPort.EnableMouseTranslation = _toolButtons.SelectedButton == buttonToolMove;
                _tileMapViewPort.Redraw();
            };

            NewTilemap(16);
        }

        private void SaveTilemap(object sender, EventArgs e)
        {
            saveFileDialog.Filter = "(*.lua)|*.lua|All files (*.*)|*.*";
            DialogResult result = saveFileDialog.ShowDialog();
            if (result == DialogResult.OK || result == DialogResult.Yes)
            {
                System.IO.File.WriteAllText(saveFileDialog.FileName, _tilemap.ToString());
            }
        }

        public void NewTilemap(int cellsize)
        {
            _tilemap = new Tilemap();
            _tileMapViewPort.CellSize = cellsize;
            _tileButtons.Clear();
            _layerList.Clear();
            _layerList.Tilemap = _tilemap;
            UpdateLayers();

            _tileMapViewPort.Redraw();
        }

        public void OpenTilemap(int cellsize, string path)
        {
            string file;
            try
            {
                file = System.IO.File.ReadAllText(path);
            }
            catch (Exception e)
            {
                MessageBox.Show($"Exception opening file({path}):\n{e.Message}", "Caught exception");
                return;
            }
            _tilemap = new Tilemap(file);
            _layerList.Tilemap = _tilemap;
            _tileMapViewPort.CellSize = cellsize;
            _tileButtons.Clear();

            Dictionary<string, Image> images = new Dictionary<string, Image>();
            for (int i = 0; i < _tilemap.Tiles.Count; i++)
            {
                Tile tile = _tilemap.Tiles[i];
                List<int> quads = tile.Quad.Values;
                if (quads.Count < 4)
                    continue;
                if (_tilesets.ContainsKey(tile.Image))
                {
                    if (images.ContainsKey(_tilesets[tile.Image].Path) == false)
                        images[_tilesets[tile.Image].Path] = new Bitmap(_tilesets[tile.Image].Path);
                    _tileMapViewPort.Images[i] = ViewPort.CropImage(images[_tilesets[tile.Image].Path], quads[0], quads[1], quads[2], quads[3], quads[2], quads[3]);

                    AddNewTileButton(tile, ViewPort.CropImage(images[_tilesets[tile.Image].Path], quads[0], quads[1], quads[2], quads[3], 40, 40));
                }
                else
                {
                    MessageBox.Show($"No tile set {tile.Image}, import tileset then re-import tilemap", "Missing textures");
                    NewTilemap(cellsize);
                    return;
                }
            }

            _layerList.Clear();

            for (int i = 0; i < _tilemap.Layers.Count; i++)
            {
                _layerList.Add(_tilemap.Layers[i], toolTip);
            }

            _tileMapViewPort.Redraw();
        }

        public void NewTileSet(TileSet.TileSetData tileSetData)
        {
            if (tileSetData != null)
            {
                if (tileSetData.PreviousExportString != null && tileSetData.PreviousExportString != tileSetData.ExportString)
                {
                    _tilesets.Remove(tileSetData.PreviousExportString);
                    foreach (Tile tile in _tilemap.Tiles)
                        if (tile.Image == tileSetData.PreviousExportString)
                            tile.Image = tileSetData.ExportString;
                }

                _tilesets[tileSetData.ExportString] = tileSetData;

                SetTileSelectionMenuItem();
            }
        }

        public void NewTile(Tile tile, Image full, Image thumbnail, int previousIndex = -1)
        {
            Button bu = flowLayoutPanelTiles.Controls.OfType<Button>().SingleOrDefault((b) => b.Tag as Tile == tile);
            if (bu != null)
            {
                _tileButtons.SetSelectedButton(bu);
                return;
            }

            if (previousIndex != -1 && previousIndex < _tilemap.Tiles.Count && previousIndex > -1)
            {
                Tile t = _tilemap.Tiles[previousIndex];
                _tilemap.Tiles[previousIndex] = tile;
                Button button = _tileButtons.FindButtonWithTag(t);
                button.Tag = tile;
                button.Image = thumbnail;
                _tileMapViewPort.Images[previousIndex] = full;
                _tileButtons.SetSelectedButton(button);
                _tileMapViewPort.Redraw();
            }
            else
            {
                _tilemap.Tiles.Add(tile);
                _tileMapViewPort.Images[_tilemap.Tiles.Count() - 1] = full;
                Button button = AddNewTileButton(tile, thumbnail);
                _tileButtons.SetSelectedButton(button);
            }
        }

        public void NewBitmaskTile(TileEditor.BitmaskTiles tiles, int previousIndex = -1)
        {
            throw new NotImplementedException();
        }

        public void RedrawViewPort()
        {
            _tileMapViewPort.Redraw();
        }

        public void UpdateLayers()
        {
            _tileMapViewPort.Layers = _layerList.Items;
        }

        private Button AddNewTileButton(Tile tile, Image thumbnail)
        {
            Button button = new Button
            {
                Size = new Size(44, 44),
                Image = thumbnail,
                Tag = tile
            };

            _tileButtons.Add(button);

            button.Paint += (sender, e) =>
            {
                Graphics g = e.Graphics;
                HatchBrush b = new HatchBrush(HatchStyle.Percent50, Color.LightGray, Color.White);
                g.FillRectangle(b, new Rectangle(new Point(2, 2), new Size(40, 40)));
                b.Dispose();
                if (button.Image != null)
                    g.DrawImage(button.Image, 2, 2);
            };

            string tip = $"{tile.Image}\n";
            List<int> quads = tile.Quad.Values;
            for (int i = 0; i < quads.Count; i += 4)
                tip += $"{quads[i]},{quads[i + 1]},{quads[i + 2]},{quads[i + 3]}  ";
            toolTip.SetToolTip(button, tip);

            flowLayoutPanelTiles.Controls.Add(button);

            return button;
        }

        public bool MouseInput(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (_toolButtons.SelectedButton == buttonToolPaint)
                {
                    AddTile();
                    _tileMapViewPort.Redraw();
                }
                else if (_toolButtons.SelectedButton == buttonToolEraser)
                {
                    RemoveTile();
                    _tileMapViewPort.Redraw();
                }
                return true;
            }
            return false;
        }

        public Tile GetSelectedTile()
        {
            return (Tile)GetSelectedTileButtonObject();
        }

        private object GetSelectedTileButtonObject()
        {
            Button button = _tileButtons.SelectedButton;
            if (button == null || button.Tag == null)
                return null;
            return button.Tag;
        }

        public int GetSelectedTileIndex()
        {
            Button button = _tileButtons.SelectedButton;
            if (button == null || button.Tag == null)
                return -1;
            return _tilemap.Tiles.FindIndex(tile => tile == (Tile)button.Tag);
        }

        private void AddTile()
        {
            LayerAttributes att = _layerList.SelectedItem?.Attributes;
            if (att == null)
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
                MessageBox.Show("Could not find selected Tile");
                return;
            }

            LayerTile layerTile = new LayerTile(index + 1, _tileMapViewPort.GetCell.X, _tileMapViewPort.GetCell.Y);
            att.layer.Set(layerTile);
        }

        private void RemoveTile()
        {
            LayerAttributes att = _layerList.SelectedItem.Attributes;
            if (att == null)
            {
                _layerList.Flash();
                return;
            }

            att.layer.Remove(_tileMapViewPort.GetCell.X, _tileMapViewPort.GetCell.Y);
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
                Program.TileEditor.NewTilesetImage(_tilesets[selectedName], false);
        }

        private void NewBitmaskTileSelectCallback(string selectedName)
        {
            if (selectedName != null)
                Program.TileEditor.NewTilesetImage(_tilesets[selectedName], true);
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
