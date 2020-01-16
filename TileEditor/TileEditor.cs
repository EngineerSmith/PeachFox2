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

        private TileSet.TileSetData _tileSetData = null;
        private int previousIndex = -1;

        private bool _bitmaskMode = false;
        private List<Button> _bitmaskButtons;

        private enum BitmaskMode
        {
            Four,
            Eight
        }

        public int CellSize
        {
            get => _tileViewPort.CellSize;
            set
            {
                _tileViewPort.CellSize = value;
                try
                {
                    numericWidth.Value = value;
                    numericHeight.Value = value;
                    numericX.Increment = value;
                    numericY.Increment = value;
                }
                catch(System.Exception e)
                {
                    MessageBox.Show($"Survived Exception\nException: {e.Message}", "Exception While setting CellSize");
                    Close();
                }
            }
        }

        public TileEditorForm() 
        {
            InitializeComponent();
            Hide();

            this.Disposed += new EventHandler(DisposeForm);
            this.FormClosing += new FormClosingEventHandler(HideForm);

            _tileViewPort = new TileViewPort(viewPort);
            CellSize = 16; // Default

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

            buttonExport.Click += (sender, e) =>
            {
                Export();
                Hide();
            };

            tabControl.SelectedIndexChanged += (sender, e) =>
            {
                if (!_bitmaskMode && tabControl.SelectedTab == tabPageBitmask)
                {
                    tabControl.SelectedTab = tabPageQuads;
                    MessageBox.Show("Create bitmask tile through dropdown menus");
                }
            };

            checkBoxBitmaskMode.CheckedChanged += (sender, e) =>
            {
                if (checkBoxBitmaskMode.Checked)
                    SetBitmaskMode(BitmaskMode.Eight);
                else
                    SetBitmaskMode(BitmaskMode.Four);
            };

            SetBitmaskMode(BitmaskMode.Four);
        }

        public void NewTilesetImage(TileSet.TileSetData tileSet, bool bitmask, object obj = null, int index = -1)
        {
            Show();
            Activate();
            _bitmaskMode = bitmask;
            _tileSetData = tileSet;
            Bitmap image = new Bitmap(tileSet.Path);
            _tileViewPort.Image = image;
            previousIndex = index;
            if (bitmask == false)
            {
                tabControl.SelectedTab = tabPageQuads;
                Tile tile = (Tile)obj;
                List<string> quadsStr = null;
                if (tile != null && tile.Quad.Values.Count % 4 == 0)
                {
                    List<int> quads = tile.Quad.Values;
                    quadsStr = new List<string>(quads.Count / 4);
                    for (int i = 0; i < quads.Count; i += 4)
                        quadsStr.Add(_quadSettings.GenerateString(quads[i], quads[i + 1], quads[i + 2], quads[i + 3]));
                    if (quads.Count > 4)
                        numericTime.Value = (decimal)tile.Time;
                }
                _quadList.Clear(quadsStr);
            }
            else
            {
                tabControl.SelectedTab = tabPageBitmask;
            }
            _quadSettings.ImageWidth = image.Width;
            _quadSettings.ImageHeight = image.Height;
            CellSize = tileSet.CellSize;
            _exportSettings.Update();
        }

        public void Export()
        {
            var quads = _quadList.ExportQuads();
            Tile tile = new Tile(new Quad(quads), _tileSetData.ExportString, quads.Count > 4 ? (double?)numericTime.Value : null);
            Program.TileMapEditor.NewTile(tile, _tileViewPort.GetImage(), _tileViewPort.GetThumbnail(40, 40), previousIndex);
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

        private void BitmaskToggle(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (button != null)
            {
                if (button.BackColor == Color.Gainsboro)
                    button.BackColor = Color.LightYellow;
                else if (button.BackColor == Color.LightYellow)
                    button.BackColor = Color.Gainsboro;
                else
                    MessageBox.Show("Unknown bitmask button color");
                button.Refresh();
            }
            ChangeBitmaskTile();
        }

        private void SetBitmaskMode(BitmaskMode mode)
        {
            switch (mode)
            {
                case BitmaskMode.Four:
                    _bitmaskButtons = new List<Button>
                    {
                        SetButtonTag(buttonMask2,1),
                        SetButtonTag(buttonMask16,2),
                        SetButtonTag(buttonMask64,4),
                        SetButtonTag(buttonMask8,8),
                    };
                    buttonMask1.Visible = false;
                    buttonMask4.Visible = false;
                    buttonMask32.Visible = false;
                    buttonMask128.Visible = false;
                    break;
                case BitmaskMode.Eight:
                    _bitmaskButtons = new List<Button>
                    {
                        buttonMask1,
                        SetButtonTag(buttonMask2,2),
                        buttonMask4,
                        SetButtonTag(buttonMask8,8),
                        SetButtonTag(buttonMask16,16),
                        buttonMask32,
                        SetButtonTag(buttonMask64,64),
                        buttonMask128,
                    };
                    buttonMask1.Visible = true;
                    buttonMask4.Visible = true;
                    buttonMask32.Visible = true;
                    buttonMask128.Visible = true;
                    break;
            }
            ChangeBitmaskTile();
        }

        private Button SetButtonTag(Button button, int tag)
        {
            button.Tag = tag;
            button.Text = tag.ToString();
            return button;
        }

        private void ChangeBitmaskTile()
        {
            int bitmask = 0;
            foreach (Button button in _bitmaskButtons)
            {
                if (button.BackColor == Color.LightYellow)
                    bitmask += (int)button.Tag;
            }
            buttonTILE.Text = bitmask.ToString();
        }
    }
}