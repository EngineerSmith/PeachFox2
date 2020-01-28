using System.Windows.Forms;
using System.Drawing;
using PeachFox.TileMapEditor;

namespace PeachFox
{
    partial class TileMapEditorForm
    {
        private LayerList _layerList;

        private void AddLayerUi()
        {
            _layerList = new LayerList(flowLayoutPanelLayers);

            buttonLayerNew.Click += (sender, e) =>
            {
                Program.NewLayerEditorForm(LayerCallback);
            };

            buttonLayerEdit.Click += (sender, e) =>
            {
                if (_layerList.SelectedItem != null)
                    Program.NewLayerEditorForm(LayerCallback, _layerList.SelectedItem.Layer);
            };
        }

        private void NewLayer(Tilemap tilemap)
        {
            _layerList.Clear();
            _layerList.Tilemap = tilemap;
        }
    }
}
