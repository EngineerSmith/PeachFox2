using System;
using System.Windows.Forms;

namespace PeachFox.TileEditor
{
    public class ExportSettings
    {
        public NumericUpDown Time { get; set; }
        public Label LabelTime {  get; set; }

        public Button ButtonExport { get; set; }

        private bool _showTime;
        private bool _showExport;

        private readonly QuadList _list;

        public ExportSettings(QuadList list)
        {
            _list = list;
        }

        public void Update()
        {
            if (_list.List.Items.Count > 1)
            {
                _showTime = true;
                _showExport = true;
            }
            else if (_list.List.Items.Count > 0)
            {
                _showTime = false;
                _showExport = true;
            }
            else
            {
                _showTime = false;
                _showExport = false;
            }

            SetVisibility();
        }

        private void SetVisibility()
        {
            Time.Enabled = _showTime;
            LabelTime.Enabled = _showTime;

            ButtonExport.Enabled = _showExport;
        }
    }
}
