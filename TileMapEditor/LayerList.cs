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
            item.GroupBox.MouseDown += MouseDown;
            SetSelected(item);
            Program.TileMapEditor.UpdateLayers();
        }

        public void SetSelected(LayerListItem item)
        {
            SelectedItem?.Selected(false);
            SelectedItem = item;
            SelectedItem?.Selected(true);
        }

        private void UpdateOrder()
        {
            Items = new List<LayerListItem>(Panel.Controls.Count);
            foreach (Control control in Panel.Controls)
                Items.Add((LayerListItem)control.Tag);

            List<Layer> layers = new List<Layer>(Items.Count);
            for (int i = 0; i < Items.Count; i++)
                layers.Add(Items[i].Attributes.layer);

            Tilemap.Layers = layers;
            Program.TileMapEditor.UpdateLayers();
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
            if ((e.Button == MouseButtons.Right) || (e.Button == MouseButtons.Left && sender == SelectedItem))
            {
                Panel.DoDragDrop(sender, DragDropEffects.Move);
                Panel.Tag = ((Control)sender).Tag;
            }
        }

        private void DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void DragDrop(object sender, DragEventArgs e)
        {
            LayerListItem item = (LayerListItem)Panel.Tag;
            if (item == null)
                return;
            Panel.Tag = null;
            Point point = Panel.PointToClient(new Point(e.X, e.Y));
            point.Y -= Panel.AutoScrollPosition.Y;
            int index = (int)((double)point.Y / (double)(item.GroupBox.Height + 3));
            if (index < 0 || index >= Items.Count)
                index = Items.Count - 1;
            int i = Items.FindIndex(x => x == item);
            if (i == (index-Items.Count-1)*-1)
                return;
            Panel.Controls.SetChildIndex(item.GroupBox, index);
            UpdateOrder();
        }
    }
}
