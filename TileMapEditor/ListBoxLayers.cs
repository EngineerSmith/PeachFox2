using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;

namespace PeachFox.TileMapEditor
{
    class ListBoxLayers : Flashable
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
            : base(layers)
        {
            Layers = layers;
            _toolTip = tip;
        }

        private System.Random rnd = new System.Random((int)(System.DateTime.Now.Ticks/2));

        public void Add(Layer layer)
        {
            string name = layer.GetValue("name")?.Value.GetString();
            name = name == null || name == "" ? $"Layer {rnd.Next(0, 89999) + 10000}" : name;
            int index = Layers.Items.Add(new LayerAttributes(name, layer));
            Layers.SetSelected(index, true);
        }

        public void UpdateSelected()
        {
            LayerAttributes att = (LayerAttributes)Layers.SelectedItem;
            if (att != null)
            {
                string name = att.layer.GetValue("name")?.Value.GetString();
                if ((name == null || name == "") && att.name.Length == 11 && att.name.Substring(0, 6) == "Layer ")//TODO Replace with Regex
                    return;
                name = name == null || name == "" ? $"Layer {rnd.Next(0,89999) + 10000}" : name;
                att.name = name;
                Layers.Items[Layers.SelectedIndex] = Layers.SelectedItem;
            }
        }

        private void ToolTip(object sender, MouseEventArgs e)
        {
            int index = Layers.IndexFromPoint(e.X, e.Y);
            if (index != -1 && index < Layers.Items.Count)
            {
                string str = "";
                foreach (var kvp in ((LayerAttributes)Layers.Items[index]).layer.GetValues())
                    str += $"\"{kvp.Key.GetString()}\" = \"{kvp.Value.GetString()}\"\n";
                if (_toolTip.GetToolTip(Layers) != str)
                    _toolTip.SetToolTip(Layers, str);
            }
            else
                _toolTip.SetToolTip(Layers, string.Empty);
        }

    }

    public class LayerAttributes
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
