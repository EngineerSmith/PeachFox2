using System;
using System.Windows.Forms;
using PeachFox.TileEditor;

namespace PeachFox
{
    public partial class TileEditorForm : Form
    {
        public TileEditorForm() 
        {
            InitializeComponent();

            this.Disposed += new EventHandler(DisposeForm);
        }

        public void DisposeForm(object sender, EventArgs e)
        {
           TileSetBox.Dispose();
        }
    }
}
