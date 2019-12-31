using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using PeachFox.TileMapEditor;

namespace PeachFox
{
    public partial class TileMapEditorForm : Form
    {
        private TileMapViewPort _tileMapViewPort;

        public TileMapEditorForm()
        {
            InitializeComponent();

            _tileMapViewPort = new TileMapViewPort(viewPort);
        }
    }
}
