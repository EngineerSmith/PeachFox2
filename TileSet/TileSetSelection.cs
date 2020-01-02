using System.Collections.Generic;
using System.Windows.Forms;
using PeachFox.TileSet;

public delegate void SelectFormCallback(string selectedName);

namespace PeachFox
{
    public partial class TileSetSelectionForm : Form
    {
        public TileSetSelectionForm(List<string> tileSetNames, bool showNewTileSet, SelectFormCallback callback)
        {
            InitializeComponent();

            buttonNewTileSet.Visible = showNewTileSet;
            buttonNewTileSet.Enabled = showNewTileSet;

            comboBoxTileSets.Items.AddRange(tileSetNames.ToArray());

            buttonSelect.Click += (sender, e) => {
                if (comboBoxTileSets.SelectedItem != null)
                    callback(comboBoxTileSets.SelectedItem.ToString());
                else
                    callback(null);
                this.Close();
            };

            buttonCancel.Click += (sender, e) =>
            {
                callback(null);
                this.Close();
            };

            buttonNewTileSet.Click += (sender, e) =>
            {
                Program.NewTileSetNewForm(newCallback);
            };
        }

        private void newCallback(TileSetData tileSetData)
        {
            if (tileSetData != null)
            {
                Program.TileMapEditor.NewTileSet(tileSetData);
                int index = comboBoxTileSets.Items.Add(tileSetData.ExportString);
                comboBoxTileSets.SelectedIndex = index;
            }
        }
    }
}
