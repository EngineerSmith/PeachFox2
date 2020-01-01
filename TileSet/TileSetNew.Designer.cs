namespace PeachFox
{
    partial class TileSetNewForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.buttonOpen = new System.Windows.Forms.Button();
            this.textBoxFilePath = new System.Windows.Forms.TextBox();
            this.buttonImport = new System.Windows.Forms.Button();
            this.infoBox = new System.Windows.Forms.RichTextBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.numericCellSize = new System.Windows.Forms.NumericUpDown();
            this.labelCellSize = new System.Windows.Forms.Label();
            this.textBoxExportString = new System.Windows.Forms.TextBox();
            this.labelExportString = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericCellSize)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "TileSet.png";
            // 
            // buttonOpen
            // 
            this.buttonOpen.Location = new System.Drawing.Point(12, 12);
            this.buttonOpen.Name = "buttonOpen";
            this.buttonOpen.Size = new System.Drawing.Size(75, 23);
            this.buttonOpen.TabIndex = 0;
            this.buttonOpen.Text = "Open Tile Set";
            this.buttonOpen.UseVisualStyleBackColor = true;
            // 
            // textBoxFilePath
            // 
            this.textBoxFilePath.Enabled = false;
            this.textBoxFilePath.Location = new System.Drawing.Point(94, 14);
            this.textBoxFilePath.Name = "textBoxFilePath";
            this.textBoxFilePath.Size = new System.Drawing.Size(315, 20);
            this.textBoxFilePath.TabIndex = 1;
            // 
            // buttonImport
            // 
            this.buttonImport.Location = new System.Drawing.Point(334, 130);
            this.buttonImport.Name = "buttonImport";
            this.buttonImport.Size = new System.Drawing.Size(75, 23);
            this.buttonImport.TabIndex = 2;
            this.buttonImport.Text = "Import";
            this.buttonImport.UseVisualStyleBackColor = true;
            // 
            // infoBox
            // 
            this.infoBox.Enabled = false;
            this.infoBox.Location = new System.Drawing.Point(12, 71);
            this.infoBox.Name = "infoBox";
            this.infoBox.Size = new System.Drawing.Size(397, 51);
            this.infoBox.TabIndex = 3;
            this.infoBox.Text = "test\ntest";
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(13, 130);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 4;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // numericCellSize
            // 
            this.numericCellSize.Location = new System.Drawing.Point(94, 43);
            this.numericCellSize.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericCellSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericCellSize.Name = "numericCellSize";
            this.numericCellSize.Size = new System.Drawing.Size(75, 20);
            this.numericCellSize.TabIndex = 5;
            this.numericCellSize.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // labelCellSize
            // 
            this.labelCellSize.AutoSize = true;
            this.labelCellSize.Location = new System.Drawing.Point(40, 45);
            this.labelCellSize.Name = "labelCellSize";
            this.labelCellSize.Size = new System.Drawing.Size(47, 13);
            this.labelCellSize.TabIndex = 6;
            this.labelCellSize.Text = "Cell Size";
            // 
            // textBoxExportString
            // 
            this.textBoxExportString.Location = new System.Drawing.Point(248, 42);
            this.textBoxExportString.Name = "textBoxExportString";
            this.textBoxExportString.Size = new System.Drawing.Size(160, 20);
            this.textBoxExportString.TabIndex = 7;
            // 
            // labelExportString
            // 
            this.labelExportString.AutoSize = true;
            this.labelExportString.Location = new System.Drawing.Point(175, 45);
            this.labelExportString.Name = "labelExportString";
            this.labelExportString.Size = new System.Drawing.Size(67, 13);
            this.labelExportString.TabIndex = 8;
            this.labelExportString.Text = "Export String";
            // 
            // TileSetNewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 163);
            this.ControlBox = false;
            this.Controls.Add(this.labelExportString);
            this.Controls.Add(this.textBoxExportString);
            this.Controls.Add(this.labelCellSize);
            this.Controls.Add(this.numericCellSize);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.infoBox);
            this.Controls.Add(this.buttonImport);
            this.Controls.Add(this.textBoxFilePath);
            this.Controls.Add(this.buttonOpen);
            this.MaximumSize = new System.Drawing.Size(437, 202);
            this.MinimumSize = new System.Drawing.Size(437, 202);
            this.Name = "TileSetNewForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tile Set Properties";
            ((System.ComponentModel.ISupportInitialize)(this.numericCellSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button buttonOpen;
        private System.Windows.Forms.TextBox textBoxFilePath;
        private System.Windows.Forms.Button buttonImport;
        private System.Windows.Forms.RichTextBox infoBox;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.NumericUpDown numericCellSize;
        private System.Windows.Forms.Label labelCellSize;
        private System.Windows.Forms.TextBox textBoxExportString;
        private System.Windows.Forms.Label labelExportString;
    }
}