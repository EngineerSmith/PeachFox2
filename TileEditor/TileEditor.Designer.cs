namespace PeachFox{    partial class TileEditorForm    {		        /// <summary>        /// Required designer variable.        /// </summary>        private System.ComponentModel.IContainer components = null;        /// <summary>        /// Clean up any resources being used.        /// </summary>        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>        protected override void Dispose(bool disposing)        {            if (disposing && (components != null))            {                components.Dispose();            }            base.Dispose(disposing);        }        #region Windows Form Designer generated code        /// <summary>        /// Required method for Designer support - do not modify        /// the contents of this method with the code editor.        /// </summary>        private void InitializeComponent()        {            this.viewPort = new System.Windows.Forms.PictureBox();
            this.groupBoxViewPort = new System.Windows.Forms.GroupBox();
            this.groupBoxControls = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBoxQuads = new System.Windows.Forms.GroupBox();
            this.listBox = new System.Windows.Forms.ListBox();
            this.groupBoxButtons = new System.Windows.Forms.GroupBox();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.groupBoxQuadSettings = new System.Windows.Forms.GroupBox();
            this.labelHeight = new System.Windows.Forms.Label();
            this.labelWidth = new System.Windows.Forms.Label();
            this.labelY = new System.Windows.Forms.Label();
            this.labelX = new System.Windows.Forms.Label();
            this.numericHeight = new System.Windows.Forms.NumericUpDown();
            this.numericWidth = new System.Windows.Forms.NumericUpDown();
            this.numericY = new System.Windows.Forms.NumericUpDown();
            this.numericX = new System.Windows.Forms.NumericUpDown();
            this.groupBoxExportSettings = new System.Windows.Forms.GroupBox();
            this.buttonExport = new System.Windows.Forms.Button();
            this.labelTime = new System.Windows.Forms.Label();
            this.numericTime = new System.Windows.Forms.NumericUpDown();
            this.buttonClear = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.viewPort)).BeginInit();
            this.groupBoxViewPort.SuspendLayout();
            this.groupBoxControls.SuspendLayout();
            this.flowLayoutPanel.SuspendLayout();
            this.groupBoxQuads.SuspendLayout();
            this.groupBoxButtons.SuspendLayout();
            this.groupBoxQuadSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericX)).BeginInit();
            this.groupBoxExportSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericTime)).BeginInit();
            this.SuspendLayout();
            // 
            // viewPort
            // 
            this.viewPort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.viewPort.Cursor = System.Windows.Forms.Cursors.Hand;
            this.viewPort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewPort.Location = new System.Drawing.Point(3, 16);
            this.viewPort.Name = "viewPort";
            this.viewPort.Size = new System.Drawing.Size(478, 342);
            this.viewPort.TabIndex = 0;
            this.viewPort.TabStop = false;
            // 
            // groupBoxViewPort
            // 
            this.groupBoxViewPort.Controls.Add(this.viewPort);
            this.groupBoxViewPort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxViewPort.Location = new System.Drawing.Point(0, 0);
            this.groupBoxViewPort.Name = "groupBoxViewPort";
            this.groupBoxViewPort.Padding = new System.Windows.Forms.Padding(3, 3, 203, 3);
            this.groupBoxViewPort.Size = new System.Drawing.Size(684, 361);
            this.groupBoxViewPort.TabIndex = 1;
            this.groupBoxViewPort.TabStop = false;
            this.groupBoxViewPort.Text = "View Port";
            // 
            // groupBoxControls
            // 
            this.groupBoxControls.Controls.Add(this.flowLayoutPanel);
            this.groupBoxControls.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBoxControls.Location = new System.Drawing.Point(484, 0);
            this.groupBoxControls.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.groupBoxControls.Name = "groupBoxControls";
            this.groupBoxControls.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.groupBoxControls.Size = new System.Drawing.Size(200, 361);
            this.groupBoxControls.TabIndex = 1;
            this.groupBoxControls.TabStop = false;
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.Controls.Add(this.groupBoxQuads);
            this.flowLayoutPanel.Controls.Add(this.groupBoxButtons);
            this.flowLayoutPanel.Controls.Add(this.groupBoxQuadSettings);
            this.flowLayoutPanel.Controls.Add(this.groupBoxExportSettings);
            this.flowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel.Location = new System.Drawing.Point(3, 13);
            this.flowLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(194, 348);
            this.flowLayoutPanel.TabIndex = 0;
            // 
            // groupBoxQuads
            // 
            this.groupBoxQuads.Controls.Add(this.listBox);
            this.groupBoxQuads.Location = new System.Drawing.Point(3, 0);
            this.groupBoxQuads.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.groupBoxQuads.Name = "groupBoxQuads";
            this.groupBoxQuads.Padding = new System.Windows.Forms.Padding(3, 3, 3, 1);
            this.groupBoxQuads.Size = new System.Drawing.Size(188, 99);
            this.groupBoxQuads.TabIndex = 0;
            this.groupBoxQuads.TabStop = false;
            this.groupBoxQuads.Text = "Quads";
            // 
            // listBox
            // 
            this.listBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox.FormattingEnabled = true;
            this.listBox.Location = new System.Drawing.Point(3, 16);
            this.listBox.Margin = new System.Windows.Forms.Padding(3, 3, 3, 4);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(182, 82);
            this.listBox.TabIndex = 0;
            // 
            // groupBoxButtons
            // 
            this.groupBoxButtons.Controls.Add(this.buttonClear);
            this.groupBoxButtons.Controls.Add(this.buttonAdd);
            this.groupBoxButtons.Controls.Add(this.buttonRemove);
            this.groupBoxButtons.Location = new System.Drawing.Point(3, 99);
            this.groupBoxButtons.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.groupBoxButtons.Name = "groupBoxButtons";
            this.groupBoxButtons.Size = new System.Drawing.Size(188, 47);
            this.groupBoxButtons.TabIndex = 4;
            this.groupBoxButtons.TabStop = false;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(2, 14);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(60, 23);
            this.buttonAdd.TabIndex = 1;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = true;
            // 
            // buttonRemove
            // 
            this.buttonRemove.Location = new System.Drawing.Point(64, 14);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(60, 23);
            this.buttonRemove.TabIndex = 2;
            this.buttonRemove.Text = "Remove";
            this.buttonRemove.UseVisualStyleBackColor = true;
            // 
            // groupBoxQuadSettings
            // 
            this.groupBoxQuadSettings.Controls.Add(this.labelHeight);
            this.groupBoxQuadSettings.Controls.Add(this.labelWidth);
            this.groupBoxQuadSettings.Controls.Add(this.labelY);
            this.groupBoxQuadSettings.Controls.Add(this.labelX);
            this.groupBoxQuadSettings.Controls.Add(this.numericHeight);
            this.groupBoxQuadSettings.Controls.Add(this.numericWidth);
            this.groupBoxQuadSettings.Controls.Add(this.numericY);
            this.groupBoxQuadSettings.Controls.Add(this.numericX);
            this.groupBoxQuadSettings.Location = new System.Drawing.Point(3, 146);
            this.groupBoxQuadSettings.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.groupBoxQuadSettings.Name = "groupBoxQuadSettings";
            this.groupBoxQuadSettings.Size = new System.Drawing.Size(188, 115);
            this.groupBoxQuadSettings.TabIndex = 3;
            this.groupBoxQuadSettings.TabStop = false;
            this.groupBoxQuadSettings.Text = "Quad Settings";
            // 
            // labelHeight
            // 
            this.labelHeight.AutoSize = true;
            this.labelHeight.Location = new System.Drawing.Point(4, 90);
            this.labelHeight.Name = "labelHeight";
            this.labelHeight.Size = new System.Drawing.Size(38, 13);
            this.labelHeight.TabIndex = 7;
            this.labelHeight.Text = "Height";
            // 
            // labelWidth
            // 
            this.labelWidth.AutoSize = true;
            this.labelWidth.Location = new System.Drawing.Point(7, 67);
            this.labelWidth.Name = "labelWidth";
            this.labelWidth.Size = new System.Drawing.Size(35, 13);
            this.labelWidth.TabIndex = 6;
            this.labelWidth.Text = "Width";
            // 
            // labelY
            // 
            this.labelY.AutoSize = true;
            this.labelY.Location = new System.Drawing.Point(27, 45);
            this.labelY.Name = "labelY";
            this.labelY.Size = new System.Drawing.Size(14, 13);
            this.labelY.TabIndex = 5;
            this.labelY.Text = "Y";
            // 
            // labelX
            // 
            this.labelX.AutoSize = true;
            this.labelX.Location = new System.Drawing.Point(28, 21);
            this.labelX.Name = "labelX";
            this.labelX.Size = new System.Drawing.Size(14, 13);
            this.labelX.TabIndex = 4;
            this.labelX.Text = "X";
            // 
            // numericHeight
            // 
            this.numericHeight.Location = new System.Drawing.Point(46, 88);
            this.numericHeight.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericHeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericHeight.Name = "numericHeight";
            this.numericHeight.Size = new System.Drawing.Size(134, 20);
            this.numericHeight.TabIndex = 3;
            this.numericHeight.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericWidth
            // 
            this.numericWidth.Location = new System.Drawing.Point(46, 65);
            this.numericWidth.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericWidth.Name = "numericWidth";
            this.numericWidth.Size = new System.Drawing.Size(134, 20);
            this.numericWidth.TabIndex = 2;
            this.numericWidth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericY
            // 
            this.numericY.Location = new System.Drawing.Point(45, 42);
            this.numericY.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericY.Name = "numericY";
            this.numericY.Size = new System.Drawing.Size(134, 20);
            this.numericY.TabIndex = 1;
            // 
            // numericX
            // 
            this.numericX.Location = new System.Drawing.Point(45, 19);
            this.numericX.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericX.Name = "numericX";
            this.numericX.Size = new System.Drawing.Size(134, 20);
            this.numericX.TabIndex = 0;
            // 
            // groupBoxExportSettings
            // 
            this.groupBoxExportSettings.Controls.Add(this.buttonExport);
            this.groupBoxExportSettings.Controls.Add(this.labelTime);
            this.groupBoxExportSettings.Controls.Add(this.numericTime);
            this.groupBoxExportSettings.Location = new System.Drawing.Point(3, 261);
            this.groupBoxExportSettings.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.groupBoxExportSettings.Name = "groupBoxExportSettings";
            this.groupBoxExportSettings.Size = new System.Drawing.Size(188, 76);
            this.groupBoxExportSettings.TabIndex = 5;
            this.groupBoxExportSettings.TabStop = false;
            this.groupBoxExportSettings.Text = "Export Settings";
            // 
            // buttonExport
            // 
            this.buttonExport.Location = new System.Drawing.Point(104, 46);
            this.buttonExport.Name = "buttonExport";
            this.buttonExport.Size = new System.Drawing.Size(75, 23);
            this.buttonExport.TabIndex = 2;
            this.buttonExport.Text = "Export";
            this.buttonExport.UseVisualStyleBackColor = true;
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.Location = new System.Drawing.Point(11, 21);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(30, 13);
            this.labelTime.TabIndex = 1;
            this.labelTime.Text = "Time";
            // 
            // numericTime
            // 
            this.numericTime.DecimalPlaces = 6;
            this.numericTime.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericTime.Location = new System.Drawing.Point(46, 19);
            this.numericTime.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericTime.Name = "numericTime";
            this.numericTime.Size = new System.Drawing.Size(133, 20);
            this.numericTime.TabIndex = 0;
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(126, 14);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(60, 23);
            this.buttonClear.TabIndex = 3;
            this.buttonClear.Text = "Clear All";
            this.buttonClear.UseVisualStyleBackColor = true;
            // 
            // TileEditorForm
            // 
            this.ClientSize = new System.Drawing.Size(684, 361);
            this.Controls.Add(this.groupBoxControls);
            this.Controls.Add(this.groupBoxViewPort);
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(700, 400);
            this.Name = "TileEditorForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ShowIcon = false;
            this.Text = "Tile Editor";
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.ShowHelp);
            ((System.ComponentModel.ISupportInitialize)(this.viewPort)).EndInit();
            this.groupBoxViewPort.ResumeLayout(false);
            this.groupBoxControls.ResumeLayout(false);
            this.flowLayoutPanel.ResumeLayout(false);
            this.groupBoxQuads.ResumeLayout(false);
            this.groupBoxButtons.ResumeLayout(false);
            this.groupBoxQuadSettings.ResumeLayout(false);
            this.groupBoxQuadSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericX)).EndInit();
            this.groupBoxExportSettings.ResumeLayout(false);
            this.groupBoxExportSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericTime)).EndInit();
            this.ResumeLayout(false);

		}



        #endregion

        private System.Windows.Forms.PictureBox viewPort;
        private System.Windows.Forms.GroupBox groupBoxViewPort;
        private System.Windows.Forms.GroupBox groupBoxControls;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
        private System.Windows.Forms.GroupBox groupBoxQuads;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonRemove;
        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.GroupBox groupBoxQuadSettings;
        private System.Windows.Forms.Label labelHeight;
        private System.Windows.Forms.Label labelWidth;
        private System.Windows.Forms.Label labelY;
        private System.Windows.Forms.Label labelX;
        private System.Windows.Forms.NumericUpDown numericHeight;
        private System.Windows.Forms.NumericUpDown numericWidth;
        private System.Windows.Forms.NumericUpDown numericY;
        private System.Windows.Forms.NumericUpDown numericX;
        private System.Windows.Forms.GroupBox groupBoxButtons;
        private System.Windows.Forms.GroupBox groupBoxExportSettings;
        private System.Windows.Forms.Button buttonExport;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.NumericUpDown numericTime;
        private System.Windows.Forms.Button buttonClear;
    }}