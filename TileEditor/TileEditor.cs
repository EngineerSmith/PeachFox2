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
        private int _bitmaskSelected = -1;
        private List<Button> _bitmaskButtons;
        private BitmaskTiles _bitmaskTiles = null;

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

            _quadSettings = new QuadSettings(_quadList, _exportSettings, UpdateBitmaskTileButton)
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
                    DialogResult result = MessageBox.Show("Do you want to convert your tile to bitmasked?", "Convert to Bitmask Tile", MessageBoxButtons.YesNo); //TODO ask if they want to convert Tile into Bitmasked tile
                    if (result == DialogResult.Yes)
                    {
                        _bitmaskMode = true;
                        _bitmaskTiles = new BitmaskTiles()
                        {
                            Mode = _bitmaskButtons.Count,
                        };
                        ChangeBitmaskTile(0);
                        UpdateBitmaskTileButton();
                    }
                    else
                        tabControl.SelectedTab = tabPageQuads;
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

        public void ShowTileEditor(TileSet.TileSetData tileSet, bool bitmask, object obj = null, int index = -1)
        {
            Show();
            Activate();
            _bitmaskMode = bitmask;
            _tileSetData = tileSet;
            Bitmap image = new Bitmap(tileSet.Path);
            _tileViewPort.Image = image;
            previousIndex = index;
            buttonTILE.BackgroundImage = null;
            if (bitmask == false)
            {
                tabControl.SelectedTab = tabPageQuads;
                if (obj is ClassicTile classicTile)
                {
                    SetQuads(classicTile.Quads);
                    numericTime.Value = (decimal)classicTile.Time;
                }
                else
                    SetQuads(null);
            }
            else
            {
                if (obj == null)
                {
                    _bitmaskTiles = new BitmaskTiles()
                    {
                        Mode = _bitmaskButtons.Count,
                    };
                }
                else
                {
                    _bitmaskTiles = (BitmaskTiles)obj;
                    UpdateBitmaskTileButton();
                }
                tabControl.SelectedTab = tabPageBitmask;
                ChangeBitmaskTile(0);
            }
            _quadSettings.ImageWidth = image.Width;
            _quadSettings.ImageHeight = image.Height;
            CellSize = tileSet.CellSize;
            _exportSettings.Update();
        }

        private void SetQuads(List<int> quads)
        {
            List<string> quadsStr = null;
            if (quads != null && quads.Count % 4 == 0)
            {
                quadsStr = new List<string>(quads.Count / 4);
                for (int i = 0; i < quads.Count; i += 4)
                    quadsStr.Add(_quadSettings.GenerateString(quads[i], quads[i + 1], quads[i + 2], quads[i + 3]));
            }
            if (_bitmaskMode)
                UpdateBitmaskTile();
            _quadList.Clear(quadsStr);
        }

        private void UpdateBitmaskTile()
        {
            BitmaskTile tile = GetSelectedBitmaskTile();
            List<int> exportQuads = _quadList.ExportQuads();
            if (tile == null && exportQuads.Count > 0)
            {
                tile = new BitmaskTile()
                {
                    Bit = _bitmaskSelected,
                    Image = _tileSetData.ExportString,
                    Quads = exportQuads,
                    Time = (float)numericTime.Value,
                    Thumbnail = _tileViewPort.GetThumbnail(45, 45),
                    TileImage = _tileViewPort.GetTileImage(),
                };
                _bitmaskTiles.Tiles.Add(tile);
            }
            else if (tile != null && exportQuads.Count > 0)
            {
                tile.Quads = exportQuads;
                tile.Time = (float)numericTime.Value;
                tile.Thumbnail = _tileViewPort.GetThumbnail(45, 45);
                tile.TileImage = _tileViewPort.GetTileImage();
            }
            else if (tile != null)
            {
                _bitmaskTiles.Tiles.Remove(tile);
            }
        }

        public void Export()
        {
            if (!_bitmaskMode)
            {
                ClassicTile tile = new ClassicTile()
                {
                    Quads = _quadList.ExportQuads(),
                    Image = _tileSetData.ExportString,
                    Time = (float)numericTime.Value,
                    Thumbnail = _tileViewPort.GetThumbnail(40, 40),
                    TileImage = _tileViewPort.GetTileImage(),
                };
                Program.TileMapEditor.NewTile(tile, previousIndex);
            }
            else
            {
                ChangeBitmaskTile(0);
                _bitmaskTiles.Thumbnail = _tileViewPort.GetThumbnail(40, 40);
                if (_bitmaskTiles.Tiles.Count != (_bitmaskTiles.Mode ^ 2))
                {
                    DialogResult result = MessageBox.Show(
                        $"You're have selected {_bitmaskTiles.Tiles.Count} for your bitmasked tile out of the required {_bitmaskTiles.Mode ^ 2}. Are you sure you want to continue?\n" +
                        "If you have a missing tiles and their bit is selected. It will remove that tile from the tilemap.",
                        "Warning",MessageBoxButtons.OKCancel);
                    if (result != DialogResult.OK)
                        return;
                }
                Program.TileMapEditor.NewBitmaskTile(_bitmaskTiles, previousIndex);
            }
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
                    button.BackColor = Color.SkyBlue;
                else if (button.BackColor == Color.SkyBlue)
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
                        buttonMask1,
                        buttonMask2,
                        buttonMask4,
                        buttonMask8,
                    };
                    buttonMask16.Visible = false;
                    buttonMask32.Visible = false;
                    buttonMask64.Visible = false;
                    buttonMask128.Visible = false;
                    break;
                case BitmaskMode.Eight:
                    _bitmaskButtons = new List<Button>
                    {
                        buttonMask1,
                        buttonMask2,
                        buttonMask4,
                        buttonMask8,
                        buttonMask16,
                        buttonMask32,
                        buttonMask64,
                        buttonMask128,
                    };
                    buttonMask16.Visible = true;
                    buttonMask32.Visible = true;
                    buttonMask64.Visible = true;
                    buttonMask128.Visible = true;
                    break;
                default:
                    throw new NotImplementedException();
            }
            if (_bitmaskTiles != null)
                _bitmaskTiles.Mode = _bitmaskButtons.Count;
            ChangeBitmaskTile();
        }

        private Button SetButtonTag(Button button, int tag)
        {
            button.Tag = tag;
            button.Text = tag.ToString();
            return button;
        }

        private void ChangeBitmaskTile(int bitmask = -1)
        {
            if (_bitmaskMode == false)
                return;
            if (bitmask == -1)
            {
                bitmask = 0;
                foreach (Button button in _bitmaskButtons)
                {
                    if (button.BackColor == Color.SkyBlue)
                        bitmask += (int)button.Tag;
                }
            }
            buttonTILE.Text = bitmask.ToString();
            SelectBitmaskTile(bitmask);
        }

        private void SelectBitmaskTile(int bitmask)
        {
            BitmaskTile tile = FindBitmaskTile(bitmask);
            if (tile != null)
            {
                SetQuads(tile.Quads);
                if (tile.Quads.Count > 4)
                    numericTime.Value = (decimal)tile.Time;
                buttonTILE.BackgroundImage = tile.Thumbnail;
            }
            else
            {
                SetQuads(null);
                buttonTILE.BackgroundImage = null;
            }
            buttonTILE.Refresh();
            _bitmaskSelected = bitmask;
        }

        private BitmaskTile FindBitmaskTile(int bitmask)
        {
            if (_bitmaskTiles == null)
                return null;
            foreach (var tile in _bitmaskTiles.Tiles)
                if (tile.Bit == bitmask)
                    return tile;
            return null;
        }

        private BitmaskTile GetSelectedBitmaskTile()
        {
            return FindBitmaskTile(_bitmaskSelected);
        }

        private void UpdateBitmaskTileButton()
        {
            if (_bitmaskMode == false)
                return;
            if (_quadList.ExportQuads().Count > 0)
                buttonTILE.BackgroundImage = _tileViewPort.GetThumbnail(45, 45);
            else
                buttonTILE.BackgroundImage = null;
            buttonTILE.Refresh();
        }
    }
}