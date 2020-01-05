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
        private Dictionary<string, TileSet.TileSetData> _tilesets = new Dictionary<string, TileSet.TileSetData>();

        private Tilemap _tilemap = new Tilemap();

        private ListBoxLayers _layerList;

        private SelectableButtons _tileButtons = new SelectableButtons();
        private SelectableButtons _toolButtons = new SelectableButtons();

        public TileMapEditorForm()
        {
            InitializeComponent();

            _tileMapViewPort = new TileMapViewPort(viewPort)
            {
                Tilemap = _tilemap
            };

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

            flowLayoutPanelTiles.Click += (sender, e) => { _tileButtons.SetSelectedButton(null); };

            _layerList = new ListBoxLayers(listBoxLayers, toolTip);

            foreach(var layer in _tilemap.Layers) //TODO on load/New of tilemap
                _layerList.Add(layer);

            buttonLayerNew.Click += (sender, e) =>
            {
                Program.NewLayerEditorForm(LayerCallback);
            };

            buttonLayerEdit.Click += (sender, e) =>
            {
                if (listBoxLayers.SelectedItem != null)
                    Program.NewLayerEditorForm(LayerCallback, ((LayerAttributes)listBoxLayers.SelectedItem).layer);
            };

            _toolButtons.Add(buttonToolMove);
            _toolButtons.Add(buttonToolPaint);
            _toolButtons.Add(buttonToolEraser);
            _toolButtons.SetSelectedButton(buttonToolMove);

            _toolButtons.Callback = () =>
            {
                _tileMapViewPort.EnableMouseTranslation = 
                            _toolButtons.SelectedButton == buttonToolMove || 
                            _toolButtons.SelectedButton == buttonToolEraser;
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

        public void NewTile(Tile tile, Image full, Image thumbnail, int previousIndex = -1)
        {
            Button bu = flowLayoutPanelTiles.Controls.OfType<Button>().SingleOrDefault((b) => b.Tag as Tile == tile);
            if (bu != null)
            {
                _tileButtons.SetSelectedButton(bu);
                return;
            }

            if (previousIndex != -1 && previousIndex < _tilemap.Tiles.Count && previousIndex > -1)
                _tilemap.Tiles[previousIndex] = tile;
            else
            {
                _tilemap.Tiles.Add(tile);
                _tileMapViewPort.Images.Add(_tilemap.Tiles.Count-1, full);
                Button button = AddNewTileButton(tile, thumbnail);
                _tileButtons.SetSelectedButton(button);

            }
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

        public void MouseInput(MouseEventArgs e)
        { 
            if (e.Button == MouseButtons.Left)
            {
                if(_toolButtons.SelectedButton == buttonToolPaint)
                {
                    AddTile();
                    _tileMapViewPort.Redraw();
                }
                else if (_toolButtons.SelectedButton == buttonToolEraser)
                {
                    RemoveTile();
                }
            }
        }

        private void AddTile()
        {
            LayerAttributes att = (LayerAttributes)listBoxLayers.SelectedItem;
            if (att == null)
            {
                _layerList.Flash();
                return;
            }
            Button button = _tileButtons.SelectedButton;
            if (button == null || button.Tag != null)
            {
                //TODO add user feedback
                return;
            }
            Tile tag = (Tile)button.Tag;
            int index = _tilemap.Tiles.FindIndex(tile => tile == tag);
            if (index == -1)
            {
                MessageBox.Show("Could not find selected Tile");
                return;
            }

            LayerTile layerTile = new LayerTile(index, _tileMapViewPort.GetCell.X, _tileMapViewPort.GetCell.Y);
            att.layer.Set(layerTile);
        }

        private void RemoveTile()
        {
            LayerAttributes att = (LayerAttributes)listBoxLayers.SelectedItem;
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
                Program.TileEditor.NewTilesetImage(_tilesets[selectedName]);
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
                _layerList.Add(layer);
            }
            else 
                _layerList.UpdateSelected();
        }
    }
}
