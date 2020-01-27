using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

public delegate void SelectedButtonChanged();

namespace PeachFox.TileMapEditor
{
    class SelectableButtons
    {
        private readonly List<Button> _buttons = new List<Button>();
        private Button _selectedButton = null;
        private static readonly Random _random = new Random();
        public Button SelectedButton 
        {
            get
            {
                if (SelectMultiple && SelectedButtons.Count > 1)
                    return SelectedButtons[_random.Next(0, SelectedButtons.Count-1)];
                return _selectedButton;
            }
            private set => _selectedButton = value;
        }
        public List<Button> SelectedButtons { get; private set; } = new List<Button>();

        public SelectedButtonChanged Callback = null;
        
        public bool SelectMultiple { get; private set; } = false;

        public SelectableButtons(bool multiple = false)
        {
            SelectMultiple = multiple;
        }

        public void Add(Button button)
        {
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 2;
            button.FlatAppearance.BorderColor = Color.LightGray;

            button.MouseEnter += MouseEnter;
            button.MouseLeave += MouseLeave;

            button.Click += (sender, e) => { SetSelectedButton(button); };
            _buttons.Add(button);
        }

        public void SetSelectedButton(Button button)
        {
            if (button != null && !_buttons.Contains(button))
                throw new Exception("Button not part of SelectableButtons");

            if (button == null)
            {
                SelectedButton = null;
                ClearSelectedButtons();
                Callback?.Invoke();
                return;
            }

            if (SelectMultiple && (Control.ModifierKeys == Keys.Shift || Control.ModifierKeys == Keys.Control))
                SelectedButtons.Add(button);
            else if (SelectedButton != null)
            {
                ClearSelectedButtons();
                SelectedButton.FlatAppearance.BorderColor = Color.LightGray;
            }
            SelectedButton = button;
            button.FlatAppearance.BorderColor = Color.MediumBlue;

            Callback?.Invoke();
        }

        public Button FindButtonWithTag(object tag)
        {
            return _buttons.SingleOrDefault(b => b.Tag == tag);
        }

        public void Clear()
        {
            SetSelectedButton(null);
            foreach (Button button in _buttons)
                button.Dispose();
            _buttons.Clear();
        }

        public void ClearSelectedButtons()
        {
            foreach (Button b in SelectedButtons)
                b.FlatAppearance.BorderColor = Color.LightGray;
            SelectedButtons.Clear();
        }

        private void MouseEnter(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            SetBorderColor(button, Color.FromArgb(110, 130, 190));

        }

        private void MouseLeave(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            SetBorderColor(button, Color.LightGray);
        }

        private void SetBorderColor(Button button, Color c)
        {
            if ((SelectMultiple == false && button != SelectedButton) ||
                (SelectMultiple && SelectedButtons.Contains(button) == false))
                button.FlatAppearance.BorderColor = c;
        }
    }
}
