using System.Windows.Forms;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace PeachFox.TileEditor
{
    public class QuadList
    {
        private ListBox _listBox;

        public ListBox List
        {
            get => _listBox;
            set
            {
                _listBox = value;
                _listBox.MouseDown += new MouseEventHandler(MouseDown);
            }
        }

        private TileViewPort TileViewPort;

        public QuadList(ListBox list, TileViewPort tileViewPort)
        {
            List = list;
            TileViewPort = tileViewPort;
        }

        public int[] GetValues(string str)
        {
            Regex rx = new Regex(@"(\d*),(\d*),(\d*),(\d*)");
            var matches = rx.Match(str);
            if (matches.Success)
            {
                return new int[]{int.Parse(matches.Groups[1].Value),
                                int.Parse(matches.Groups[2].Value),
                                int.Parse(matches.Groups[3].Value),
                                int.Parse(matches.Groups[4].Value)};
            }
            return null;
        }

        public List<int> GetViewPortQuads()
        {
            var selectedItem = _listBox.SelectedItem;
            List<int> list = new List<int>(_listBox.Items.Count * 5);
            foreach (var item in _listBox.Items)
            {
                int[] values = GetValues(item.ToString());
                if (values != null)
                {
                    list.Add(values[0]);
                    list.Add(values[1]);
                    list.Add(values[2]);
                    list.Add(values[3]);
                    list.Add(item == selectedItem ? 0 : 1);
                }
            }
            return list;
        }

        public List<int> ExportQuads()
        {
            List<int> list = new List<int>(_listBox.Items.Count * 4);
            foreach (var item in _listBox.Items)
            {
                int[] values = GetValues(item.ToString());
                if (values != null)
                    list.AddRange(values);
            }
            return list;
        }

        public void UpdateViewPort()
        {
            TileViewPort.Quads = GetViewPortQuads();
            TileViewPort.Redraw();
        }

        public void RemoveSelected()
        {
            if (_listBox.SelectedItem != null)
            {
                _listBox.Items.Remove(_listBox.SelectedItem);
                _listBox.ClearSelected();
            }
            UpdateViewPort();
        }

        public void Clear(List<string> quads = null)
        {
            _listBox.Items.Clear();
            _listBox.ClearSelected();

            if (quads != null)
                foreach (string quad in quads)
                    _listBox.Items.Add(quad);
            UpdateViewPort();
        }

        private void MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                _listBox.ClearSelected();
            }
            UpdateViewPort();
        }
    }
}