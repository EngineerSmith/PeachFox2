using System.Windows.Forms;
using System.Drawing;

namespace PeachFox.TileMapEditor
{
    class LayerListItem
    {
        private static System.Random RND = new System.Random((int)(System.DateTime.Now.Ticks / 2));

        public LayerAttributes Layer;

        public Panel Panel;
        public PictureBox PictureBox;
        public Label Label;
        public CheckBox Checkbox;

        public Panel CreateFormItem(ToolTip toolTip)
        {
            Panel = new Panel()
            {
                Tag = Layer,
                Dock = DockStyle.Top,
                Width = 220, 
                Height = 60,
            };

            PictureBox = new PictureBox()
            {
                Height = 44,
                Width = 100,
                Location = new Point(5, 8),
                Dock = DockStyle.Left,
            };

            Label = new Label
            {
                Text = Layer.name,
                Location = new Point(110,23),
            };

            Checkbox = new CheckBox
            {
                Checked = false,
                Dock = DockStyle.Right,
            };

            Panel.Controls.Add(PictureBox);
            Panel.Controls.Add(Label);
            Panel.Controls.Add(Checkbox);

            UpdateToolTip(toolTip);

            return Panel;
        }

        public void UpdateToolTip(ToolTip toolTip)
        {
            string str = "";
            foreach (var kvp in Layer.layer.GetValues())
                str += $"\"{kvp.Key.GetString()}\" = \"{kvp.Value.GetString()}\"\n";
            toolTip.SetToolTip(Panel, str);
        }

        public void UpdateName()
        {
            Label.Text = GenerateName();
        }

        private string GenerateName()
        {
            string name = Layer.layer.GetValue("name")?.Value.GetString();
            if ((name == null || name == "") && Layer.name != null && Layer.name.Length == 12 && Layer.name.Substring(0, 6) == "Layer ")//TODO Replace with Regex
                return Layer.name;
            return name == null || name == "" ? $"Layer {RND.Next(0, 899999) + 10000}" : name;
        }
    }
}
