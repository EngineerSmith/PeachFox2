using System;
using System.Drawing;
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

            TileSetBox.PictureBox = viewPort;
            TileSetBox.CellSize = 16;
            TileSetBox.Image = new Bitmap("C:\\dev\\YogGJ\\Assets\\Logo.png");
        }

        public void DisposeForm(object sender, EventArgs e)
        {
           TileSetBox.Dispose();
        }
    }
}
