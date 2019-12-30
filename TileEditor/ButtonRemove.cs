using System;
using System.Windows.Forms;

namespace PeachFox.TileEditor
{
    class ButtonRemove
    {
        private Button _buttonSelected;

        public Button ButtonSelected
        {
            get => _buttonSelected;
            set
            {
                _buttonSelected = value;
                _buttonSelected.Click += RemoveSelected;
            }
        }

        private Button _buttonAll;
        public Button ButtonAll
        {
            get => _buttonAll;
            set
            {
                _buttonAll = value;
                _buttonAll.Click += RemoveAll;
            }
        }

        private QuadList _quadList;
        private ExportSettings _exportSettings;

        public ButtonRemove(QuadList quadList, ExportSettings exportSettings)
        {
            _quadList = quadList;
            _exportSettings = exportSettings;
        }

        private void RemoveSelected(object sender, EventArgs e)
        {
            _quadList.RemoveSelected();
            _exportSettings.Update();
        }

        private void RemoveAll(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Are you sure to remove all quads?",
                                                "Confirm removal of all quads!",
                                                MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
                _quadList.Clear();

            _exportSettings.Update();
        }
    }
}
