using System.Windows.Forms;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

public delegate void SelectedButtonChanged();

namespace PeachFox.TileMapEditor
{
    class SelectableButtons
    {
        private List<Button> _buttons = new List<Button>();

        public Button SelectedButton = null;

        public SelectedButtonChanged Callback = null;

        public void Add(Button button)
        {
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 2;
            button.FlatAppearance.BorderColor = Color.LightGray;

            button.MouseEnter += (sender, e) => { if (button != SelectedButton) button.FlatAppearance.BorderColor = Color.FromArgb(110, 130, 190); };
            button.MouseLeave += (sender, e) => { if (button != SelectedButton) button.FlatAppearance.BorderColor = Color.LightGray; };

            button.Click += (sender, e) => { SetSelectedButton(button); };
            _buttons.Add(button);
        }

        public void SetSelectedButton(Button button)
        {
            if (button != null && !_buttons.Contains(button))
                throw new System.Exception("Button not part of SelectableButtons");

            if (SelectedButton != null)
                SelectedButton.FlatAppearance.BorderColor = Color.LightGray;
            SelectedButton = button;
            if (SelectedButton != null)
                button.FlatAppearance.BorderColor = Color.MediumBlue;

            Callback?.Invoke();
        }

        public Button FindButtonWithTag(object tag)
        {
            return _buttons.SingleOrDefault(b => b.Tag == tag);
        }
    }
}
