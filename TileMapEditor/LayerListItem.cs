using System.Windows.Forms;
using System.Drawing;

namespace PeachFox.TileMapEditor
{
    class LayerListItem
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
                BackColor = Color.Green,
                Enabled = false,
            };

            Checkbox = new CheckBox
            {
                Checked = true,
                Location = new Point(110,18),
            };

            Checkbox.MouseEnter += Enter;
            Checkbox.MouseLeave += Leave;

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
    }
}
