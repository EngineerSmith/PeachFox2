using System.Windows.Forms;
using PeachFox.TileMapEditor;

namespace PeachFox
{
    partial class TileMapEditorForm
    {
        public int CellSize { get => _tileMapViewPort.CellSize; }

        private TileMapViewPort _tileMapViewPort;

        private void AddViewPort()
        {
            _tileMapViewPort = new TileMapViewPort(viewPort);
        }

        private void SetCellSize(int cellsize)
        {
            _tileMapViewPort.CellSize = cellsize;
            toolStripTextBoxCellSize.Text = cellsize.ToString();
        }

        public void RedrawViewPort()
        {
            _tileMapViewPort.Redraw();
        }

        public void UpdateLayers()
        {
            _tileMapViewPort.Layers = _layerList.Items;
        }
    }
}
