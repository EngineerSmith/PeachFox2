using System;
using System.Drawing;
using System.Windows.Forms;
using PeachFox.TileEditor;

namespace PeachFox
{
    public partial class TileEditorForm : Form
    {
        private TileViewPort _tileSetBox;
        private QuadList _quadList;
        private QuadSettings _quadSettings;
        private ExportSettings _exportSettings;

        private ButtonRemove _buttonRemove;

        public TileEditorForm(Image image) 
        {
            InitializeComponent();

            this.Disposed += new EventHandler(DisposeForm);
            _tileSetBox = new TileViewPort(viewPort)
            {
                CellSize = 16,
                Image = image
            };

            listBox.SelectedValueChanged += QuadSelectionChanged;

            _quadList = new QuadList(listBox, _tileSetBox);

            _exportSettings = new ExportSettings(_quadList)
            {
                Time = numericTime,
                LabelTime = labelTime,
                ButtonExport = buttonExport
            };

            _quadSettings = new QuadSettings(_quadList, _exportSettings)
            {
                X = numericX,
                Y = numericY,
                Width = numericWidth,
                Height = numericHeight,
                AddButton = buttonAdd,
                ImageWidth = image.Width,
                ImageHeight = image.Height
            };

            _buttonRemove = new ButtonRemove(_quadList, _exportSettings)
            {
                ButtonSelected = buttonRemove,
                ButtonAll = buttonClear
            };
        }

        public void NewTilesetImage(Image image)
        {
            _tileSetBox.Image = image;
            _quadList.Clear();
            _quadSettings.ImageWidth = image.Width;
            _quadSettings.ImageHeight = image.Height;
        }

        private void DisposeForm(object sender, EventArgs e)
        {
            _tileSetBox.Dispose();
        }

        private void QuadSelectionChanged(object sender, EventArgs e)
        {
            if (listBox.SelectedItem != null)
            {
                int[] values = _quadList.GetValues(listBox.SelectedItem.ToString());
                if (values != null)
                {
                    _quadSettings.SetValues(values[0], values[1], values[2], values[3]);
                }
            }
        }

        private void ShowHelp(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBox.Show("This window helps you select a tile.\nUse muiltple Quads for animated tiles.\n\nControls:\n\tRight-click inside Quads to unselect.\n\tMiddle-click in view port to re-centre image.","Help");
            e.Cancel = true;
        }
    }
}
