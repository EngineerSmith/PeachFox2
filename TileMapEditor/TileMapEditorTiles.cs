using System.Windows.Forms;
using PeachFox.TileMapEditor;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections.Generic;

namespace PeachFox
{
    partial class TileMapEditorForm
    {
        private SelectableButtons _tileButtons = new SelectableButtons(true);
        private FlashableLayout _layoutTiles;

        private void AddTileUi()
        {
            flowLayoutPanelTiles.Click += (sender, e) => { _tileButtons.SetSelectedButton(null); };
            _layoutTiles = new FlashableLayout(flowLayoutPanelTiles);

            buttonNewTile.Click += (sender, e) => Program.NewTileSetSelectionForm(new List<string>(_projectSettings.TileSets.Keys), true, NewTileSelectCallback);

            buttonEditTile.Click += (sender, e) =>
            { 
                int index = GetSelectedTileIndex(); //Rewrite
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
        }

        private void ClearTiles()
        {
            _tileButtons.Clear();
        }

        public void NewTile(Tile tile, int previousIndex = -1)
        {
            Button bu = _tileButtons.FindButtonWithTag(tile);
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
                _tileMapViewPort.Images[_tilemap.Tiles.Count - 1] = tile.TileImage;
                Button button = AddNewTileButton(tile, tile.Thumbnail);
                _tileButtons.SetSelectedButton(button);
            }
        }

        public void NewBitmaskTile(TileEditor.BitmaskTiles tiles, int previousIndex = -1)
        {
            Button bu = _tileButtons.FindButtonWithTag(tiles);
            if (bu != null)
            {
                _tileButtons.SetSelectedButton(bu);
                return;
            }

            if (previousIndex != -1)
            {
                //TODO update existing
                //Would need to know all the previous Tile indices - Bit order and others could change
            }
            else
            {
                foreach (Tile tile in tiles.GetTiles())
                {
                    _tilemap.Tiles.Add(tile);
                    _tileMapViewPort.Images[_tilemap.Tiles.Count - 1] = tile.TileImage;
                }
                Button button = AddNewTileButton(tiles, tiles.Thumbnail);
                _tileButtons.SetSelectedButton(button);
            }
        }

        private Button AddNewTileButton(object tag, Image thumbnail)
        {
            Button button = new Button
            {
                Size = new Size(44, 44),
                Image = thumbnail,
                Tag = tag
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
                //g.DrawString(button.Text, ); // TODO draw text
            };

            string tip = "";
            if (tag is ClassicTile classicTile)
            {
                tip += $"{classicTile.Image}\n";
                List<int> quads = classicTile.Quads;
                for (int i = 0; i < quads.Count; i += 4)
                    tip += $"{quads[i]},{quads[i + 1]},{quads[i + 2]},{quads[i + 3]}  ";
            }

            tip += "\nTags:\n";
            if (tag is Tile tile)
            {
                foreach (Tag t in tile.Tags)
                    tip += $"{t}\n";
                if (thumbnail == null)
                {
                    Tag name = tile.Tags.Find(t => t.Name == "name");
                    if (name != null)
                        button.Text = name.StringValue;
                }
            } 
            else if (tag is TileEditor.BitmaskTiles bitmaskTiles)
            {
                foreach (BitmaskTile btile in bitmaskTiles.Tiles)
                {
                    tip += $"[{btile.Bit}]:";
                    foreach (Tag t in btile.Tags)
                        tip += $"{t}, ";
                    tip += "\n";
                }
            }

            toolTip.SetToolTip(button, tip);

            flowLayoutPanelTiles.Controls.Add(button);
            return button;
        }

        public int GetSelectedTileIndex()
        {
            Button button = _tileButtons.SelectedButton;
            if (button == null || button.Tag == null)
                return -1;
            return _tilemap.Tiles.FindIndex(tile => tile == (Tile)button.Tag);
        }
    }
}
