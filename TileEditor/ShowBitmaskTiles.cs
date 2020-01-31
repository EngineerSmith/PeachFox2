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
                _control.MouseEnter += MouseEnter;
                _control.MouseLeave += MouseLeave;
            }
        }

        private void AddShowBitmaskTiles()
        {
            Control = buttonShowAll;
        }

        private void MouseEnter(object sender, EventArgs e)
        {

        }

        private void MouseLeave(object sender, EventArgs e)
        {

        }
    }
}
