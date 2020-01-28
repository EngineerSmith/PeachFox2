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
    }
}
