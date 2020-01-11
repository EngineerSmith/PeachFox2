using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections.Generic;

namespace PeachFox.TileMapEditor
{
    public class LayerListItem
    {
        private static readonly System.Random RND = new System.Random((int)(System.DateTime.Now.Ticks / 2));

        public LayerAttributes Attributes;

        public GroupBox GroupBox;
        public PictureBox PictureBox;
        public CheckBox Checkbox;

        private Color _boarder = Color.LightGray; 


        public LayerListItem(LayerAttributes layerAttributes)
        {
            Attributes = layerAttributes;
        }

        public LayerListItem(Layer layer)
        {
            Attributes = new LayerAttributes(layer);
        }

        public GroupBox CreateFormItem(ToolTip toolTip)
        {
            GroupBox = new GroupBox()
            {
                Tag = this,
                Size = new Size(205, 70),
                Padding = new Padding(0),
            };

            GroupBox.MouseEnter += Enter;
            GroupBox.MouseLeave += Leave;
            GroupBox.Paint += Paint;

            PictureBox = new PictureBox()
            {
                Size = new Size(100, 54),
                Location = new Point(5, 10),
                Enabled = false,
            };

            PictureBox.Paint += PaintPreview;

            Checkbox = new CheckBox
            {
                Checked = true,
                Location = new Point(110,18),
            };

            Checkbox.MouseEnter += Enter;
            Checkbox.MouseLeave += Leave;
            Checkbox.CheckedChanged += CheckedChanged;

            GroupBox.Controls.Add(PictureBox);
            GroupBox.Controls.Add(Checkbox);

            UpdateToolTip(toolTip);
            UpdateName();

            return GroupBox;
        }

        public void UpdateToolTip(ToolTip toolTip)
        {
            string str = "";
            foreach (var kvp in Attributes.layer.GetValues())
                str += $"\"{kvp.Key.GetString()}\" = \"{kvp.Value.GetString()}\"\n";
            toolTip.SetToolTip(GroupBox, str);
        }

        public void Selected(bool selected)
        {
            _boarder = selected ? Color.MediumBlue : Color.LightGray;
            GroupBox.Refresh();
        }

        public void UpdateName()
        {
            Attributes.name = GenerateName();
            Checkbox.Text = Attributes.name;
            Checkbox.Size = new Size(20+TextRenderer.MeasureText(Checkbox.Text, Control.DefaultFont).Width, Checkbox.Height);
        }

        public void Draw(Dictionary<int, Image> images, int width, int height, float translateX, float translateY, float scale)
        {
            if (width == 0 || height == 0)
            {
                Attributes.image = null;
                return;
            }
            Bitmap result = new Bitmap(width, height);
            try
            {
                Graphics g = Graphics.FromImage(result);
                g.SmoothingMode = SmoothingMode.HighSpeed;
                g.InterpolationMode = InterpolationMode.NearestNeighbor;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;

                g.ScaleTransform(scale, scale);
                g.TranslateTransform(translateX, translateY);

                foreach (LayerTile tile in Attributes.layer.Tiles)
                {
                    Image i = images[(int)tile.TileIndex];
                    g.DrawImage(i, (float)tile.X - 0.5f - 0.005f, (float)tile.Y - 0.5f - 0.005f, i.Width + 0.5f + 0.01f, i.Height + 0.5f + 0.01f);
                }
                g.Dispose();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show($"Exception while creating Layer({Attributes.name}): {ex.Message}");
                result.Dispose();
                Attributes.image = null;
                return;
            }
            Attributes.image = result;
            PictureBox.Refresh();
        }

        private string GenerateName()
        {
            string name = Attributes.layer.GetValue("name")?.Value.GetString();
            if ((name == null || name == "") && Attributes.name != null && Attributes.name.Length == 12 && Attributes.name.Substring(0, 6) == "Layer ")//TODO Replace with Regex
                return Attributes.name;
            return name == null || name == "" ? $"Layer {RND.Next(0, 899999) + 10000}" : name;
        }

        private void Enter(object sender, System.EventArgs e)
        {
            if (GroupBox.BackColor != Color.MediumBlue)
                GroupBox.BackColor = Color.LightBlue;
        }

        private void Leave(object sender, System.EventArgs e)
        {
            if (GroupBox.BackColor != Color.MediumBlue)
                GroupBox.BackColor = Color.White;
        }

        private void CheckedChanged(object sender, System.EventArgs e)
        {
            Attributes.drawToViewPort = Checkbox.Checked;
            Program.TileMapEditor.RedrawViewPort();
        }

        private void Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen p = new Pen(_boarder, 2);
            Control s = (Control)sender;
            g.DrawLine(p, 0, 5, 0, s.Height - 2);
            g.DrawLine(p, 0, 5, s.Width - 2, 5);
            g.DrawLine(p, s.Width - 2, 5, s.Width - 2, s.Height - 2);
            g.DrawLine(p, s.Width - 2, s.Height - 2, 0, s.Height - 2);
        }

        private void PaintPreview(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
            g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            
            if (Attributes.image != null)
                g.DrawImage(Attributes.image, 0,0, PictureBox.Width, PictureBox.Height);
        }
    }
}
