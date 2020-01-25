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
            _layer = layer ?? new Layer();

            buttonImport.Click += (sender, e) =>
            {
                foreach(DataGridViewRow r in dataGridViewTags.Rows)
                {
                    if (r.Cells[0].Value == null)
                        continue;
                    string key = r.Cells[0].Value as string;
                    if (r.Cells[1].Value != null && r.Cells[1].Value.ToString() != "")
                        _layer.Tags.Add(new Tag(key, r.Cells[1].Value as string));
                    else
                    {
                        int i = _layer.Tags.FindIndex(tag => tag.Name == key);
                        if (i != -1)
                            _layer.Tags.RemoveAt(i);
                    }
                }
                callback?.Invoke(_layer);
                Close();
            };

            buttonCancel.Click += (sender, e) =>
            {
                callback?.Invoke(null);
                Close();
            };
            int index = _layer.Tags.FindIndex(tag => tag.Name == "name");
            string name = null;
            if (index != -1)
                name = _layer.Tags[index].StringValue;
            textBoxName.Text = name != null ? name : "";
            textBoxName.TextChanged += (sender, e) =>
            {
                DataGridViewRow row = dataGridViewTags.Rows.OfType<DataGridViewRow>().SingleOrDefault(r => r.Cells[0].Value?.ToString() == "name");
                if (row != null)
                    row.Cells[1].Value = textBoxName.Text;
                else
                    dataGridViewTags.Rows.Add("name", textBoxName.Text);
            };

            foreach (Tag tag in _layer.Tags)
                dataGridViewTags.Rows.Add(tag.Name, tag.StringValue);
            //TODO add numbers

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
