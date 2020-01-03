using System.Windows.Forms;

namespace PeachFox.TileMapEditor
{
    class ListBoxLayers
    {
        private ListBoxDragDrop _listBoxDragDrop = new ListBoxDragDrop();
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
            }
        }

        public ListBoxLayers(ListBox layers)
        {
            Layers = layers;
        }

        public void Add(Layer layer)
        {
            string name = layer.GetValue("name")?.Value.GetString();
            name = name == null || name == "" ? $"Layer {Layers.Items.Count +1}" : name;
            Layers.Items.Add(new {name=name, layer=layer});
        }

    }
}
