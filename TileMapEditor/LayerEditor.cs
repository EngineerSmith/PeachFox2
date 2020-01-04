using System.Linq;
using System.Windows.Forms;

namespace PeachFox
{
    public delegate void LayerEditorCallback(Layer layer);
    
    public partial class LayerEditorForm : Form
    {
        private Layer _layer;
        public LayerEditorForm(LayerEditorCallback callback, Layer layer = null)
        {
            InitializeComponent();
            _layer = layer != null ? layer : new Layer();

            buttonImport.Click += (sender, e) =>
            {
                foreach(DataGridViewRow r in dataGridViewTags.Rows)
                {
                    if (r.Cells[0].Value == null)
                        continue;
                    if (r.Cells[1].Value != null && r.Cells[1].Value.ToString() != "")
                        _layer.SetValue(r.Cells[0].Value.ToString(), r.Cells[1].Value.ToString());
                    else
                        _layer.SetValue(r.Cells[0].Value?.ToString(), null);
                }
                callback?.Invoke(_layer);
                Close();
            };

            buttonCancel.Click += (sender, e) =>
            {
                callback?.Invoke(null);
                Close();
            };

            LsonLib.LsonSafeValue v = _layer.GetValue("name");
            textBoxName.Text = v != null ? v.Value.GetString() : "";
            textBoxName.TextChanged += (sender, e) =>
            {
                //if (textBoxName.Text != "")
                //    _layer.SetValue("name", textBoxName.Text);
                //else
                //    _layer.SetValue("name", null);
                DataGridViewRow row = dataGridViewTags.Rows.OfType<DataGridViewRow>().SingleOrDefault(r => r.Cells[0].Value?.ToString() == "name");
                if (row != null)
                    row.Cells[1].Value = textBoxName.Text;
                else
                    dataGridViewTags.Rows.Add("name", textBoxName.Text);
            };

            foreach( var kvp in _layer.GetValues())
                dataGridViewTags.Rows.Add(kvp.Key, kvp.Value);

            dataGridViewTags.CellValueChanged += (sender, e) =>
            {
                DataGridViewRow r = dataGridViewTags.Rows[e.RowIndex];
                if (r.Cells[0].Value.ToString() == "name")
                    textBoxName.Text = r.Cells[1].Value.ToString();
            };

            dataGridViewTags.CellValidating += (sender, e) =>
            {
                if (e.ColumnIndex != 0)
                    return;
                for (int i = 0; i < dataGridViewTags.Rows.Count; i++)
                {
                    if (i == e.RowIndex)
                        continue;
                    if (dataGridViewTags.Rows[i].Cells[0].Value?.ToString() == e.FormattedValue.ToString())
                    {
                        e.Cancel = true;
                        break;
                    }
                }
            };
        }


    }
}
