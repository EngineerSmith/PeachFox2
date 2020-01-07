using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;

namespace PeachFox.TileMapEditor
{
    class LayerList : Flashable
    {
        private Panel _panel;

        private Panel Panel
        {
            get => _panel;
            set
            {
                _panel = value;
                Panel.AllowDrop = true;
                Panel.MouseDown += MouseDown;
                Panel.DragOver += DragOver;
                Panel.DragDrop += DragDrop;
            }
        }

        private readonly Tilemap Tilemap;

        public List<LayerListItem> Items = new List<LayerListItem>();
        public LayerListItem SelectedItem { get; private set; }

        public LayerList(Panel panel, Tilemap tilemap)
            : base(panel)
        {
            Panel = panel;
            Tilemap = tilemap;
        }
        
        public void Add(Layer layer, ToolTip toolTip)
        {
            LayerListItem item = new LayerListItem(layer);
            Items.Add(item);
            Panel.Controls.Add(item.CreateFormItem(toolTip));
            item.GroupBox.Click += LayerListItemClick;
            SetSelected(item);
        }

        public void SetSelected(LayerListItem item)
        {
            SelectedItem?.Selected(false);
            SelectedItem = item;
            SelectedItem?.Selected(true);
        }

        private void UpdateOrder()
        {
            List<Layer> layers = new List<Layer>(Items.Count);
            for (int i = Items.Count - 1; i >= 0; i--)
                layers.Add(Items[i].Attributes.layer);

            Tilemap.Layers = layers;
            Program.TileMapEditor.RedrawViewPort();
        }

        private void LayerListItemClick(object sender, System.EventArgs e)
        {
            LayerListItem item = (LayerListItem)((Control)sender).Tag;
            if (Items.Contains(item))
                SetSelected(item);
        }

        private void MouseDown(object sender, MouseEventArgs e)
        {
            if (SelectedItem == null)
                return;
            Panel.DoDragDrop(SelectedItem, DragDropEffects.Move);
        }

        private void DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void DragDrop(object sender, DragEventArgs e)
        {
            Point point = Panel.PointToClient(new Point(e.X, e.Y));
            int index = point.Y / Items[0].GroupBox.Width;
            if (index < 0)
                index = Items.Count - 1;
            if (index > Items.Count)
                index = Items.Count - 1;
            int i = Items.FindIndex(x => x == SelectedItem);
            if (i == index)
                return;
            Items.Remove(SelectedItem);
            Items.Insert(index, SelectedItem);
            UpdateOrder();
        }
    }
}
