using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PeachFox
{
    //TODO move into own class
    partial class TileEditorForm
    {
        private Control _control = null;
        private Control Control
        {
            get => _control;
            set 
            {
                _control = value;
                _control.MouseEnter += MouseEnterControl;
                _control.MouseLeave += MouseLeaveControl;
            }
        }

        private List<int> _preQuads;

        private void AddShowBitmaskTiles()
        {
            Control = buttonShowAll;
        }

        private void MouseEnterControl(object sender, EventArgs e)
        {
            if (_bitmaskMode == false)
                return;
            UpdateBitmaskTile();
            _preQuads = _tileViewPort.Quads;
            _tileViewPort.Notes.Clear();
            _tileViewPort.ShowNotes = true;
            List<int> result = new List<int>();
            foreach(BitmaskTile t in _bitmaskTiles.Tiles)
            {
                if (t.Bit < 0)
                    continue;
                for(int i = 0; i < t.Quads.Count; i+=4)
                {
                    result.AddRange(new int[]{t.Quads[i],t.Quads[i+1],t.Quads[i+2],t.Quads[i+3],0});
                    _tileViewPort.Notes.Add(t.Bit);
                }
            }
            _tileViewPort.Quads = result;
        }

        private void MouseLeaveControl(object sender, EventArgs e)
        {
            if (_bitmaskMode == false)
                return;
            _tileViewPort.ShowNotes = false;
            _tileViewPort.Quads = _preQuads;
        }
    }
}
