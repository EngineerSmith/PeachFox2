﻿using System.Windows.Forms;

namespace PeachFox.TileEditor
{
    public class QuadSettings
    {
        private NumericUpDown _x;
        private NumericUpDown _y;
        private NumericUpDown _width;
        private NumericUpDown _height;

        public NumericUpDown X
        {
            get => _x;
            set
            {
                _x = value;
                _x.ValueChanged += OnChange;
            }
        }
        public NumericUpDown Y
        {
            get => _y;
            set
            {
                _y = value;
                _y.ValueChanged += OnChange;
            }
        }
        public NumericUpDown Width
        {
            get => _width;
            set 
            {
                _width = value;
                _width.ValueChanged += OnChange;
            }
        }
        public NumericUpDown Height
        {
            get => _height;
            set
            {
                _height = value;
                _height.ValueChanged += OnChange;
            }
        }

        private Button _button;
        public Button AddButton
        {
            get => _button;
            set
            {
                _button = value;
                _button.Click += AddQuad;
            }
        }

        private int _imageWidth, _imageHeight;
        public int ImageWidth 
        {
            get => _imageWidth;
            set
            {
                _imageWidth = value;
                X.Maximum = ImageWidth - Width.Value;
            }
        }
        public int ImageHeight 
        { 
            get => _imageHeight;
            set
            { 
                _imageHeight = value;
                Y.Maximum = ImageHeight - Height.Value;
            }
        }

        private QuadList _list;
        private ExportSettings _exportSettings;

        

        public QuadSettings(QuadList list, ExportSettings exportSettings)
        {
            _list = list;
            _exportSettings = exportSettings;
        }

        public void SetValues(int x, int y, int width, int height)
        {
            X.Value = x;
            X.Increment = width;
            Y.Value = y;
            Y.Increment = height;
            Width.Value = width;
            Height.Value = height;
            SetMaximum();
        }

        private void SetMaximum()
        {
            X.Maximum = ImageWidth - Width.Value;
            Y.Maximum = ImageHeight - Height.Value;
            Width.Maximum = ImageWidth; 
            Height.Maximum = ImageHeight;
        }

        private string GenerateString()
        {
            return $"{X.Value},{Y.Value},{Width.Value},{Height.Value}";
        }

        private void OnChange(object sender, System.EventArgs e)
        {
            if (_list.List.SelectedItem != null)
            {
                _list.List.Items[_list.List.SelectedIndex] = GenerateString();
                _list.UpdateViewPort();
            }
            X.Increment = Width.Value;
            Y.Increment = Height.Value;
            SetMaximum();
            _exportSettings.Update();
        }

        private void AddQuad(object sender, System.EventArgs e)
        {
            int index = _list.List.Items.Add(GenerateString());
            _list.List.SetSelected(index, true);
            _list.UpdateViewPort();
            _exportSettings.Update();
        }

    }
}
