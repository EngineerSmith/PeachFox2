using System.Collections.Generic;
using System.Windows.Forms;

namespace PeachFox.TileMapEditor
{
    class ListBoxLayers
    {
        private ListBoxDragDrop _listBoxDragDrop = new ListBoxDragDrop();
        private ToolTip _toolTip;
        private ListBox _layers;
        public ListBox Layers
        {
            get => _layers;
            set
            {
                _layers = value;
                _listBoxDragDrop.Box = Layers;
                Layers.DisplayMember = "name";
                Layers.ValueMember = "layer";
                Layers.MouseMove += ToolTip;
            }
        }

        public ListBoxLayers(ListBox layers, ToolTip tip)
        {
            Layers = layers;
            _toolTip = tip;
            Flash();
        }

        public void Flash()
        {
            int tickCount = 0;
            Timer timer = new Timer()
            {
                Interval = 310,
                Enabled = false,
            };
            timer.Tick += (sender, e) =>
            {
                if (Layers.BackColor == System.Drawing.Color.LightBlue)
                    Layers.BackColor = System.Drawing.Color.White;
                else
                    Layers.BackColor = System.Drawing.Color.LightBlue;
                if (++tickCount >= 4)
                    timer.Stop();
            };
            timer.Start();
        }

        public void Add(Layer layer)
        {
            string name = layer.GetValue("name")?.Value.GetString();
            name = name == null || name == "" ? $"Layer {Layers.Items.Count +1}" : name;
            Layers.Items.Add(new LayerAttributes(name, layer));
        }

        private void ToolTip(object sender, MouseEventArgs e)
        {
            int index = Layers.IndexFromPoint(e.X, e.Y);
            if (index != -1 && index < Layers.Items.Count)
            {
                string str = "";
                foreach (var kvp in ((LayerAttributes)Layers.Items[index]).layer.GetValues())
                    str += $"{kvp.Key} = {kvp.Value}\n";
                if (_toolTip.GetToolTip(Layers) != str)
                    _toolTip.SetToolTip(Layers, str);
            }
            else
                _toolTip.SetToolTip(Layers, string.Empty);
        }

    }

    internal struct LayerAttributes
    {
        public string name;
        public Layer layer;

        public LayerAttributes(string name, Layer layer)
        {
            this.name = name;
            this.layer = layer;
        }

        public override string ToString()
        {
            return name;
        }
    }
}
