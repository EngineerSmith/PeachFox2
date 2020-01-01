using System.Drawing;
using System.Windows.Forms;
using PeachFox.TileSet;

public delegate void NewTileSetCallback(TileSetData tileSetData);

namespace PeachFox
{
    public partial class TileSetNewForm : Form
    {
        private int _width = 1, _height = 1;
        public TileSetNewForm(NewTileSetCallback callback, TileSetData data = null)
        {
            InitializeComponent();
            EnableTileSetOptions(false);
            SetDefaultValues();

            if (data != null)
            {
                EnableTileSetOptions(true);
                Bitmap bmp = OpenImage(data.Path);
                SetBitmapOptions(bmp);
                textBoxExportString.Text = data.ExportString;
                numericCellSize.Value = data.CellSize;
            }
            else
                data = new TileSetData();

            openFileDialog.Filter = "(*.png)|*.png|All files (*.*)|*.*";

            buttonOpen.Click += (sender, e) =>
            {
                DialogResult result = openFileDialog.ShowDialog();
                string previous = textBoxFilePath.Text;
                textBoxFilePath.Text = openFileDialog.FileName;
                if (result == DialogResult.OK || result == DialogResult.Yes)
                {
                    Bitmap bmp = OpenImage(openFileDialog.FileName);
                    SetBitmapOptions(bmp);
                    if (bmp == null) 
                        return;

                    data.Path = openFileDialog.FileName;
                    if (previous == "" && textBoxExportString.Text == "")
                        textBoxExportString.Text = System.IO.Path.GetFileName(openFileDialog.FileName);
                }
            };

            numericCellSize.ValueChanged += (sender, e) =>
            {
                decimal width = numericCellSize.Value / _width;
                decimal height = numericCellSize.Value / _height;
                infoBox.Lines[1] = $"Est. cell count: Width {width}, Height {height}";
            };

            textBoxExportString.TextChanged += (sender, e) =>
            {
                textBoxExportString.Text = ShowWhiteSpace(textBoxExportString.Text);
            };

            buttonImport.Click += (sender, e) =>
            {
                if ((data.Path == null || data.Path == "") && textBoxExportString.Text.Length < 1)
                    callback(null);
                else
                {
                    data.ExportString = RemoveShowWhiteSpace(textBoxExportString.Text);
                    callback(data);
                }
                this.Close();
            };

            buttonCancel.Click += (sender, e) =>
            {
                callback(null);
                this.Close();
            };
        }

        private void EnableTileSetOptions(bool enable)
        {
            buttonImport.Enabled = enable;
            numericCellSize.Enabled = enable;
            textBoxExportString.Enabled = enable;
        }

        private void SetDefaultValues()
        {
            numericCellSize.Value = 1;
            textBoxExportString.Text = "";
            textBoxFilePath.Text = "";
            infoBox.Lines = new string[2];
        }

        private Bitmap OpenImage(string path)
        {
            Bitmap bmp;
            try
            {
                bmp = new Bitmap(openFileDialog.FileName);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception when attempted to open file as bitmap");
                return null;
            }
            return bmp;
        }

        private void SetBitmapOptions(Bitmap bmp)
        {
            if (bmp != null)
            {
                numericCellSize.Maximum = bmp.Width < bmp.Height ? bmp.Width : bmp.Height;
                infoBox.Lines[0] = $"Width {bmp.Width}px, Height {bmp.Height}px";
                EnableTileSetOptions(true);
                _width = bmp.Width;
                _height = bmp.Height;
            }
            else
            {
                infoBox.Lines[0] = "";
                EnableTileSetOptions(false);
            }
        }

        private string ShowWhiteSpace(string str)
        {
            string result = "";
            for (int i = 0; i < str.Length; i++)
                if (char.IsWhiteSpace(str[i]))
                    result += '·';
                else
                    result += str[i];
            return result;
        }

        private string RemoveShowWhiteSpace(string str)
        {
            string result = "";
            for (int i = 0; i < str.Length; i++)
                if (str[i] == '·')
                    result += ' ';
                else
                    result += str[i];
            return result;
        }
    }
}
