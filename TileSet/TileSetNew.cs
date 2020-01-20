using System.Drawing;
using System.Windows.Forms;
using PeachFox.TileSet;

public delegate void NewTileSetCallback(TileSetData tileSetData);

namespace PeachFox
{
    public partial class TileSetNewForm : Form
    {
        private int _width = 1, _height = 1;
        public TileSetNewForm(NewTileSetCallback callback, int cellSize, TileSetData data = null)
        {
            InitializeComponent();
            EnableTileSetOptions(false);
            SetDefaultValues();

            if (data != null)
            {
                EnableTileSetOptions(true);
                Bitmap bmp = OpenImage(data.Path);
                SetBitmapOptions(bmp);
                if (bmp != null)
                    textBoxFilePath.Text = data.Path;
                textBoxExportString.Text = data.ExportString;
                data.PreviousExportString = data.ExportString;
                numericCellSize.Value = data.CellSize;
            }
            else
            {
                data = new TileSetData();
                numericCellSize.Value = cellSize;
            }

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
                decimal width = _width / numericCellSize.Value;
                decimal height = _height / numericCellSize.Value;
                changeLine(infoBox, 1, $"Est. cell count: Width {width}, Height {height}, Total {(width*height)}");

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
                    data.CellSize = (int)numericCellSize.Value;
                    callback(data);
                }
                this.Close();
            };

            buttonCancel.Click += (sender, e) =>
            {
                callback?.Invoke(null);
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
                bmp = new Bitmap(path);
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
                changeLine(infoBox, 0, $"Width {bmp.Width}px, Height {bmp.Height}px");
                EnableTileSetOptions(true);
                _width = bmp.Width;
                _height = bmp.Height;
            }
            else
            {
                changeLine(infoBox, 0, "");
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

        private void changeLine(RichTextBox RTB, int line, string text)
        {
            int s1 = RTB.GetFirstCharIndexFromLine(line);
            int s2 = line < RTB.Lines.Length - 1 ?
                      RTB.GetFirstCharIndexFromLine(line + 1) - 1 :
                      RTB.Text.Length;
            RTB.Select(s1, s2 - s1);
            RTB.SelectedText = text;
        }
    }
}
