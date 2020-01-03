using System.Drawing;
using System.Windows.Forms;

public delegate void OnOrderChange(object sender, object item);

namespace PeachFox.TileMapEditor
{
    public class ListBoxDragDrop
    {
        private ListBox _box;
        public ListBox Box
        {
            get => _box;
            set
            {
                _box = value;
                _box.AllowDrop = true;
                _box.MouseDown += MouseDown;
                _box.DragOver += DragOver;
                _box.DragDrop += DragDrop;
            }
        }

        public OnOrderChange Callback = null;

        public ListBoxDragDrop(ListBox box)
        {
            Box = box;
        }

        private void MouseDown(object sender, MouseEventArgs e)
        {
            if (Box.SelectedItem == null) 
                return;
            Box.DoDragDrop(Box.SelectedItem, DragDropEffects.Move);
        }

        private void DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void DragDrop(object sender, DragEventArgs e)
        {
            Point point = Box.PointToClient(new Point(e.X, e.Y));
            int index = Box.IndexFromPoint(point);
            if (index < 0) 
                index = Box.Items.Count - 1;
            object data = Box.SelectedItem;
            Box.Items.Remove(data);
            Box.Items.Insert(index, data);
            Callback?.Invoke(Box, data);
        }
    }
}
