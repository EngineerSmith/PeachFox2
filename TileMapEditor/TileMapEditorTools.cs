using System.Windows.Forms;
using PeachFox.TileMapEditor;

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

        private bool MouseInput(MouseEventArgs e)
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
    }
}
