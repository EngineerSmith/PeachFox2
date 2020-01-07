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
        private Tilemap _tilemap;

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

        public ListBoxLayers(ListBox layers, ToolTip tip, Tilemap tilemap)
            : base(layers)
        {
            Layers = layers;
            _toolTip = tip;
            _tilemap = tilemap;

            _listBoxDragDrop.Callback = (item) => { UpdateOrder(); };
        }

        private System.Random rnd = new System.Random((int)(System.DateTime.Now.Ticks/2));

        public void Add(Layer layer)
        {
            string name = layer.GetValue("name")?.Value.GetString();
            name = name == null || name == "" ? $"Layer {rnd.Next(0, 899999) + 100000}" : name;
            int index = Layers.Items.Add(new LayerAttributes(name, layer));
            Layers.SetSelected(index, true);
        }

        public void UpdateSelected()
        {
            LayerAttributes att = (LayerAttributes)Layers.SelectedItem;
            if (att != null)
            {
                string name = att.layer.GetValue("name")?.Value.GetString();
                if ((name == null || name == "") && att.name.Length == 12 && att.name.Substring(0, 6) == "Layer ")//TODO Replace with Regex
                    return;
                name = name == null || name == "" ? $"Layer {rnd.Next(0,899999) + 10000}" : name;
                att.name = name;
                Layers.Items[Layers.SelectedIndex] = Layers.SelectedItem;
            }
        }

        private void UpdateOrder()
        {
            List<Layer> layers = new List<Layer>(Layers.Items.Count);
            for (int i = Layers.Items.Count-1; i >= 0; i--)
                layers.Add(((LayerAttributes)Layers.Items[i]).layer);

            _tilemap.Layers = layers;
            Program.TileMapEditor.RedrawViewPort();
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
}
