using System;
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

        private ProjectSettings _projectSettings = new ProjectSettings();

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
                Program.NewTileSetSelectionForm(new List<string>(_projectSettings.TileSets.Keys), false, SelectCallback);
            };

            toolStripComboBox.SelectedIndexChanged += (sender, e) =>
            {
                if (toolStripComboBox.SelectedItem != null)
                    if (_projectSettings.TileSets.ContainsKey(toolStripComboBox.SelectedItem.ToString()))
                    {
                        Program.NewTileSetNewForm(NewTileSetCallback, _projectSettings.TileSets[toolStripComboBox.SelectedItem.ToString()]);
                        return;
                    }
                Program.NewTileSetSelectionForm(new List<string>(_projectSettings.TileSets.Keys), false, SelectCallback);
            };

            SetTileSelectionMenuItem();

            loadProjectToolStripMenuItem.Click += (sender, e) =>
            {
                openFileDialog.Filter = "(*.project)|*.project|All files (*.*)|*.*";
                DialogResult result = openFileDialog.ShowDialog();
                if (result == DialogResult.OK || result == DialogResult.Yes)
                {
                    _projectSettings = Lua.LuaProjectSettings.FromLua(openFileDialog.FileName);
                    SetTileSelectionMenuItem();
                }
            };

            saveProjectToolStripMenuItem.Click += (sender, e) =>
            {
                saveFileDialog.Filter = "(*.project)|*.project|All files (*.*)|*.*";
                DialogResult result = saveFileDialog.ShowDialog();
                if (result == DialogResult.OK || result == DialogResult.Yes)
                {
                    System.IO.File.WriteAllText(saveFileDialog.FileName, Lua.LuaProjectSettings.ToLua(_projectSettings));
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
                    try
                    {
                        Tilemap map = Lua.LuaTilemap.FromLua(openFileDialog.FileName);
                        OpenTilemap(16, map); //TODO add form prompt
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show($"Caught exception trying to open Lua tilemap:\n{ex.Message}");
                    }
                }
            };

            toolStripTextBoxCellSize.TextChanged += (sender, e) =>
            {
                if (int.TryParse(toolStripTextBoxCellSize.Text, out int result) && result > 0)
                {
                    toolStripTextBoxCellSize.BackColor = Color.White;
                    SetCellSize(result);
                    _tileMapViewPort.Redraw();
                }
                else
                    toolStripTextBoxCellSize.BackColor = Color.OrangeRed;
            };

            createTileToolStripMenuItem.Click += (sender, e) => Program.NewTileSetSelectionForm(new List<string>(_projectSettings.TileSets.Keys), true, NewTileSelectCallback);
            createBitmaskTileToolStripMenuItem.Click += (sender, e) => Program.NewTileSetSelectionForm(new List<string>(_projectSettings.TileSets.Keys), true, NewBitmaskTileSelectCallback);

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
                    Program.NewLayerEditorForm(LayerCallback, _layerList.SelectedItem.Layer);
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
                System.IO.File.WriteAllText(saveFileDialog.FileName, Lua.LuaTilemap.ToLua(_tilemap));
            }
        }

        public void NewTilemap(int cellsize)
        {
            _tilemap = new Tilemap();
            SetCellSize(cellsize);
            _tileButtons.Clear();
            _layerList.Clear();
            _layerList.Tilemap = _tilemap;
            UpdateLayers();

            _tileMapViewPort.Redraw();
        }

        public void OpenTilemap(int cellsize, Tilemap tilemap)
        {
            _tilemap = tilemap;
            _layerList.Tilemap = _tilemap;
            SetCellSize(cellsize);
            _tileButtons.Clear();

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

            _tileMapViewPort.Redraw();
        }

        private void SetCellSize(int cellsize)
        {
            _tileMapViewPort.CellSize = cellsize;
            toolStripTextBoxCellSize.Text = cellsize.ToString();
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

        public void NewTile(Tile tile, int previousIndex = -1)
        {
            Button bu = flowLayoutPanelTiles.Controls.OfType<Button>().SingleOrDefault((b) => b.Tag as Tile == tile);
            if (bu != null)
            {
                _tileButtons.SetSelectedButton(bu);
                return;
            }

            if (previousIndex < _tilemap.Tiles.Count && previousIndex > -1)
            {
                Tile t = _tilemap.Tiles[previousIndex];
                _tilemap.Tiles[previousIndex] = tile;
                Button button = _tileButtons.FindButtonWithTag(t);
                button.Tag = tile;
                button.Image = tile.Thumbnail;
                _tileMapViewPort.Images[previousIndex] = tile.TileImage;
                _tileButtons.SetSelectedButton(button);
                _tileMapViewPort.Redraw();
            }
            else
            {
                _tilemap.Tiles.Add(tile);
                _tileMapViewPort.Images[_tilemap.Tiles.Count() - 1] = tile.TileImage;
                Button button = AddNewTileButton(tile, tile.Thumbnail);
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

            if (thumbnail == null)
            {
                Tag name = tile.Tags.Find(tag => tag.Name == "name");
                if (name != null)
                    button.Text = name.StringValue;
            }

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
            string tip = "";
            if (tile is ClassicTile classicTile)
            {
                tip += $"{classicTile.Image}\n";
                List<int> quads = classicTile.Quads;
                for (int i = 0; i < quads.Count; i += 4)
                    tip += $"{quads[i]},{quads[i + 1]},{quads[i + 2]},{quads[i + 3]}  ";
            }
            tip += "\nTags:\n";
            foreach (Tag tag in tile.Tags)
                tip += $"{tag}\n";
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

        private void RemoveTile()
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

        private void SetTileSelectionMenuItem()
        {
            toolStripComboBox.Items.Clear();
            toolStripComboBox.Items.AddRange(new List<string>(_projectSettings.TileSets.Keys).ToArray());
            editExistingTileSetToolStripMenuItem.Enabled = (toolStripComboBox.Items.Count != 0);
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
