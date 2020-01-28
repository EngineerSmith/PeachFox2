using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Drawing;

namespace PeachFox
{
    partial class TileMapEditorForm
    {
        private void AddMenuStrip()
        {
            addNewTileSetToolStripMenuItem.Click += (sender, e) =>
            {
                Program.NewTileSetNewForm(NewTileSetCallback);
            };

            editExistingTileSetToolStripMenuItem.Click += (sender, e) =>
            {
                Program.NewTileSetSelectionForm(new List<string>(_projectSettings.TileSets.Keys), false, SelectCallback);
            };

            toolStripComboBox.SelectedIndexChanged += (sender, e) =>
            {
                if (toolStripComboBox.SelectedItem != null)
                    if (_projectSettings.TileSets.ContainsKey(toolStripComboBox.SelectedItem.ToString()))
                    {
                        Program.NewTileSetNewForm(NewTileSetCallback, _projectSettings.TileSets[toolStripComboBox.SelectedItem.ToString()]);
                        return;
                    }
                Program.NewTileSetSelectionForm(new List<string>(_projectSettings.TileSets.Keys), false, SelectCallback);
            };

            SetTileSelectionMenuItem();

            loadProjectToolStripMenuItem.Click += (sender, e) =>
            {
                openFileDialog.Filter = "(*.project)|*.project|All files (*.*)|*.*";
                DialogResult result = openFileDialog.ShowDialog();
                if (result == DialogResult.OK || result == DialogResult.Yes)
                {
                    _projectSettings = Lua.LuaProjectSettings.FromLua(openFileDialog.FileName);
                    SetTileSelectionMenuItem();
                }
            };

            saveProjectToolStripMenuItem.Click += (sender, e) =>
            {
                saveFileDialog.Filter = "(*.project)|*.project|All files (*.*)|*.*";
                DialogResult result = saveFileDialog.ShowDialog();
                if (result == DialogResult.OK || result == DialogResult.Yes)
                {
                    System.IO.File.WriteAllText(saveFileDialog.FileName, Lua.LuaProjectSettings.ToLua(_projectSettings));
                }
            };

            saveTilemapToolStripMenuItem.Click += SaveTilemap;

            newTilemapToolStripMenuItem.Click += (sender, e) =>
            {
                NewTilemap(16); //TODO add form prompt
            };

            helpToolStripMenuItem.Click += (sender, e) => System.Diagnostics.Process.Start("https://github.com/EngineerSmith/PeachFox2/wiki");

            openTilemapToolStripMenuItem.Click += (sender, e) =>
            {
                openFileDialog.Filter = "(*.lua)|*.lua|All files (*.*)|*.*";
                DialogResult result = openFileDialog.ShowDialog();
                if (result == DialogResult.OK || result == DialogResult.Yes)
                {
                    try
                    {
                        Tilemap map = Lua.LuaTilemap.FromLua(openFileDialog.FileName);
                        OpenTilemap(16, map); //TODO add form prompt
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Caught exception trying to open Lua tilemap:\n{ex.Message}");
                    }
                }
            };

            toolStripTextBoxCellSize.TextChanged += (sender, e) =>
            {
                if (int.TryParse(toolStripTextBoxCellSize.Text, out int result) && result > 0)
                {
                    toolStripTextBoxCellSize.BackColor = Color.White;
                    SetCellSize(result);
                    _tileMapViewPort.Redraw();
                }
                else
                    toolStripTextBoxCellSize.BackColor = Color.OrangeRed;
            };

            createTileToolStripMenuItem.Click += (sender, e) => Program.NewTileSetSelectionForm(new List<string>(_projectSettings.TileSets.Keys), true, NewTileSelectCallback);
            createBitmaskTileToolStripMenuItem.Click += (sender, e) => Program.NewTileSetSelectionForm(new List<string>(_projectSettings.TileSets.Keys), true, NewBitmaskTileSelectCallback);

        }

        private void SetTileSelectionMenuItem()
        {
            toolStripComboBox.Items.Clear();
            toolStripComboBox.Items.AddRange(new List<string>(_projectSettings.TileSets.Keys).ToArray());
            editExistingTileSetToolStripMenuItem.Enabled = (toolStripComboBox.Items.Count != 0);
        }s
    }
}
