using System.Windows.Forms;
using PeachFox.TileMapEditor;
using System.Collections.Generic;

namespace PeachFox
{
    partial class TileMapEditorForm
    {
        private SelectableButtons _toolButtons = new SelectableButtons();

        private void AddTools()
        {
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
        }

        public bool MouseInput(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (_toolButtons.SelectedButton == buttonToolPaint)
                {
                    PaintTile();
                    _tileMapViewPort.Redraw();
                }
                else if (_toolButtons.SelectedButton == buttonToolEraser)
                {
                    EraseTile();
                    _tileMapViewPort.Redraw();
                }
                return true;
            }
            return false;
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
            Cell cell = _tileMapViewPort.GetCell;
            int layertileindex = FindTile(cell, layer);
            int index = -1;
            List<Cell> tilesToUpdate = new List<Cell>();
            if (button.Tag is Tile tag)
            {
                index = _tilemap.Tiles.FindIndex(tile => tile == tag);
            }
            else if(button.Tag is TileEditor.BitmaskTiles bitmaskTiles)
            {
                int bit = GetBitValue(cell, layer, bitmaskTiles, out tilesToUpdate);
                index = _tilemap.Tiles.FindIndex(tile => tile == bitmaskTiles.GetTile(bit));
            }
            if (index == -1)
            {
                MessageBox.Show("Could not find selected Tile from selected Tile button");
                return;
            }
            if (layertileindex == -1)
            {
                LayerTile layerTile = new LayerTile
                {
                    Index = index,
                    X = cell.X,
                    Y = cell.Y,
                };
                layer.Tiles.Add(layerTile);
            }
            else
            {
                LayerTile layerTile = layer.Tiles[layertileindex];
                layerTile.Index = index;
            }
            if (button.Tag is TileEditor.BitmaskTiles bitmaskTiles2) //TODO fix naming
            {
                foreach (Cell c in tilesToUpdate)
                {
                    int bit = GetBitValue(c, layer, bitmaskTiles2, out _);
                    index = _tilemap.Tiles.FindIndex(tile => tile == bitmaskTiles2.GetTile(bit));
                    int tileindex = FindTile(c, layer);
                    if (tileindex != -1)
                    {
                        LayerTile layerTile = layer.Tiles[tileindex];
                        layerTile.Index = index;
                    }
                    else
                    {
                        MessageBox.Show("Tried to update not-existant cell, will try to continue.");
                        continue;
                    }
                }
            }
        }

        private int FindTile(Cell cell, Layer layer)
        {
            return layer.Tiles.FindIndex(tile => tile.X == cell.X && tile.Y == cell.Y);
        }
        private Tile GetTile(Cell cell, Layer layer)
        {
            int index = FindTile(cell, layer);
            LayerTile t = index != -1 ? layer.Tiles[index] : null;
            return t != null ? _tilemap.Tiles[t.Index] : null;
        }

        private int GetBitValue(Cell cell, Layer layer, TileEditor.BitmaskTiles bitmaskTiles, out List<Cell> neighbours)
        {
            int bit = 0;
            neighbours = new List<Cell>();
            Cell? c; // Used to store temp values
            Tile tile;
            System.Func<Cell, int, Cell?> func = (ce, b) =>
            {
                if ((tile = GetTile(ce, layer)) != null && bitmaskTiles.IsTileInBitmask(tile))
                {
                    bit += b;
                    return ce;
                }
                return null;
            };

            if ((c = func(cell.North(CellSize), 1)) != null) 
                neighbours.Add((Cell)c);
            if ((c = func(cell.East(CellSize),  2)) != null)
                neighbours.Add((Cell)c); 
            if ((c = func(cell.South(CellSize), 4)) != null)
                neighbours.Add((Cell)c); 
            if ((c = func(cell.West(CellSize),  8)) != null)
                neighbours.Add((Cell)c);

            if(bitmaskTiles.Mode == 8)
            {
                if ((c = func(cell.NorthWest(CellSize), 16)) != null)
                    neighbours.Add((Cell)c);
                if ((c = func(cell.NorthEast(CellSize), 32)) != null)
                    neighbours.Add((Cell)c);
                if ((c = func(cell.SouthEast(CellSize), 64)) != null)
                    neighbours.Add((Cell)c);
                if ((c = func(cell.SouthWest(CellSize), 128)) != null)
                    neighbours.Add((Cell)c);
            }
            return bit;
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
    }
}
