using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using PeachFox.TileEditor;

namespace PeachFox
{
    public partial class TileEditorForm : Form
    {
        private TileViewPort _tileViewPort;
        private QuadList _quadList;
        private QuadSettings _quadSettings;
        private ExportSettings _exportSettings;

        private ButtonRemove _buttonRemove;

        public TileEditorForm() 
        {
            InitializeComponent();
            Hide();

            this.Disposed += new EventHandler(DisposeForm);
            this.FormClosing += new FormClosingEventHandler(HideForm);

            _tileViewPort = new TileViewPort(viewPort)
            {
                CellSize = 16 //TODO Make a setting
            };

            listBox.SelectedValueChanged += QuadSelectionChanged;

            _quadList = new QuadList(listBox, _tileViewPort);

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
                AddButton = buttonAdd
            };

            _buttonRemove = new ButtonRemove(_quadList, _exportSettings)
            {
                ButtonSelected = buttonRemove,
                ButtonAll = buttonClear
            };
        }

        public void NewTilesetImage(Image image, List<int> quads = null)
        {
            Show();
            Activate();
            _tileViewPort.Image = image;
            List<string> quadsStr = null;
            if (quads != null && quads.Count % 4 == 0)
            {
                quadsStr = new List<string>(quads.Count / 4);
                for (int i = 0; i < quads.Count; i += 4)
                    quadsStr.Add(_quadSettings.GenerateString(quads[i], quads[i+1], quads[i+2], quads[i+3]));
            }
            _quadList.Clear(quadsStr);
            _quadSettings.ImageWidth = image.Width;
            _quadSettings.ImageHeight = image.Height;
        }
        private void HideForm(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }

        private void DisposeForm(object sender, EventArgs e)
        {
            _tileViewPort.Dispose();
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
