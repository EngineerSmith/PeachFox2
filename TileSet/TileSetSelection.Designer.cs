namespace PeachFox
{
    partial class TileSetSelectionForm
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
            this.comboBoxTileSets = new System.Windows.Forms.ComboBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSelect = new System.Windows.Forms.Button();
            this.labelMessage = new System.Windows.Forms.Label();
            this.buttonNewTileSet = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBoxTileSets
            // 
            this.comboBoxTileSets.FormattingEnabled = true;
            this.comboBoxTileSets.Location = new System.Drawing.Point(60, 68);
            this.comboBoxTileSets.Name = "comboBoxTileSets";
            this.comboBoxTileSets.Size = new System.Drawing.Size(121, 21);
            this.comboBoxTileSets.TabIndex = 0;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(19, 115);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonSelect
            // 
            this.buttonSelect.Location = new System.Drawing.Point(148, 115);
            this.buttonSelect.Name = "buttonSelect";
            this.buttonSelect.Size = new System.Drawing.Size(75, 23);
            this.buttonSelect.TabIndex = 2;
            this.buttonSelect.Text = "Select";
            this.buttonSelect.UseVisualStyleBackColor = true;
            // 
            // labelMessage
            // 
            this.labelMessage.AutoSize = true;
            this.labelMessage.Location = new System.Drawing.Point(77, 52);
            this.labelMessage.Name = "labelMessage";
            this.labelMessage.Size = new System.Drawing.Size(85, 13);
            this.labelMessage.TabIndex = 3;
            this.labelMessage.Text = "Select a Tile Set";
            // 
            // buttonNewTileSet
            // 
            this.buttonNewTileSet.Location = new System.Drawing.Point(131, 9);
            this.buttonNewTileSet.Name = "buttonNewTileSet";
            this.buttonNewTileSet.Size = new System.Drawing.Size(104, 23);
            this.buttonNewTileSet.TabIndex = 4;
            this.buttonNewTileSet.Text = "Add New Tile Set";
            this.buttonNewTileSet.UseVisualStyleBackColor = true;
            // 
            // TileSetSelectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(245, 152);
            this.ControlBox = false;
            this.Controls.Add(this.buttonNewTileSet);
            this.Controls.Add(this.labelMessage);
            this.Controls.Add(this.buttonSelect);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.comboBoxTileSets);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(261, 191);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(261, 191);
            this.Name = "TileSetSelectionForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Select TileSet";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxTileSets;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonSelect;
        private System.Windows.Forms.Label labelMessage;
        private System.Windows.Forms.Button buttonNewTileSet;
    }
}